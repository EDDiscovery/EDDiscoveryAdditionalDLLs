﻿/*
 * Copyright © 2020 robby & EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 * 
 * EDDiscovery== typeof(not affiliated with Frontier Developments plc.
 */

using QuickJSON.Utils;
using System;
using System.Collections.Generic;

namespace QuickJSON
{
    /// <summary>
    /// Ignore attribute. Attach to an member of a class to say don't serialise this item
    /// Applicable to FromObject and ToObject
    /// </summary>
    public sealed class JsonIgnoreAttribute : Attribute 
    {                                                           
    }

    /// <summary>
    /// Name attribute. Attach to an member of a class to indicate an alternate name to use in the JSON structure from its c# name.
    /// Applicable to FromObject and ToObject.  ToObject supports multiple names (any name in JSON will match this entry), FromObject only one.
    /// </summary>
    public sealed class JsonNameAttribute : Attribute 
    {
        /// <summary> List of names for this attribute </summary>
        public string[] Names { get; set; }
        /// <summary> Constructor with name list </summary>
        public JsonNameAttribute(params string[] names) { Names = names; }
    }

    public partial class JToken
    {
        /// <summary> Convert Object to JToken tree 
        /// Beware of using this except for the simpliest classes, use one below and control the ignored/max recursion
        /// </summary>
        /// <param name="obj">Object to convert from</param>
        /// <returns>JToken tree</returns>
        public static JToken FromObject(Object obj)      
        {
            return FromObject(obj, false);
        }

        /// <summary> Convert Object to JToken tree </summary>
        /// <param name="obj">Object to convert from</param>
        /// <param name="ignoreunserialisable">If true, do not stop if an unserialisable member is found. These are self referencing members which would cause an infinite loop</param>
        /// <param name="ignored">List of ignored types not to serialise, may be null</param>
        /// <param name="maxrecursiondepth">Maximum depth to recurse through the objects heirarchy</param>
        /// <param name="membersearchflags">Member search flags, to select what types of members are serialised</param>
        /// <returns>Null if can't convert (error detected) or JToken tree</returns>
        public static JToken FromObject(Object obj, bool ignoreunserialisable, Type[] ignored = null, int maxrecursiondepth = 256, 
            System.Reflection.BindingFlags membersearchflags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static)
        {
            Stack<Object> objectlist = new Stack<object>();
            var r = FromObjectInt(obj, ignoreunserialisable, ignored, objectlist,0,maxrecursiondepth, membersearchflags);
            System.Diagnostics.Debug.Assert(objectlist.Count == 0);
            return r.IsInError ? null : r;
        }

        /// <summary> Convert Object to JToken tree </summary>
        /// <param name="obj">Object to convert from</param>
        /// <param name="ignoreunserialisable">If true, do not stop if an unserialisable member is found. These are self referencing members which would cause an infinite loop</param>
        /// <param name="ignored">List of ignored types not to serialise, may be null</param>
        /// <param name="maxrecursiondepth">Maximum depth to recurse through the objects heirarchy</param>
        /// <param name="membersearchflags">Member search flags, to select what types of members are serialised</param>
        /// <returns>JToken error type if can't convert (check with IsInError, value has error reason) or JToken tree</returns>
        public static JToken FromObjectWithError(Object obj, bool ignoreunserialisable, Type[] ignored = null, int maxrecursiondepth = 256, 
            System.Reflection.BindingFlags membersearchflags = System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static)
        {
            Stack<Object> objectlist = new Stack<object>();
            var r = FromObjectInt(obj, ignoreunserialisable, ignored, objectlist,0,maxrecursiondepth, membersearchflags);
            System.Diagnostics.Debug.Assert(objectlist.Count == 0);
            return r;
        }

        private static JToken FromObjectInt(Object o, bool ignoreunserialisable, Type[] ignored, Stack<Object> objectlist, int lvl, int maxrecursiondepth, System.Reflection.BindingFlags membersearchflags )
        {
            //System.Diagnostics.Debug.WriteLine(lvl + "From Object on " + o.GetType().Name);

            if (lvl >= maxrecursiondepth)
                return new JToken();        // returns NULL

            Type tt = o.GetType();

            if (tt.IsArray)
            {
                Array b = o as Array;

                JArray outarray = new JArray();

                objectlist.Push(o);

                for (int i = 0; i < b.Length; i++)
                {
                    object oa = b.GetValue(i);
                    if (objectlist.Contains(oa))        // self reference
                    {
                        objectlist.Pop();
                        return new JToken(TType.Error, "Self Reference in Array");
                    }

                    JToken inner = FromObjectInt(oa, ignoreunserialisable, ignored, objectlist,lvl+1, maxrecursiondepth, membersearchflags);

                    if (inner.IsInError)      // used as an error type
                    {
                        objectlist.Pop();
                        return inner;
                    }

                    outarray.Add(inner);
                }

                objectlist.Pop();
                return outarray;
            }
            else if (typeof(System.Collections.IList).IsAssignableFrom(tt))
            {
                var ilist = o as System.Collections.IList;

                JArray outarray = new JArray();

                objectlist.Push(o);

                foreach (var oa in ilist)
                {
                    if (objectlist.Contains(oa))        // self reference
                    {
                        objectlist.Pop();
                        return new JToken(TType.Error, "Self Reference in IList");
                    }

                    JToken inner = FromObjectInt(oa, ignoreunserialisable, ignored, objectlist,lvl+1, maxrecursiondepth, membersearchflags);

                    if (inner.IsInError)      // used as an error type
                    {
                        objectlist.Pop();
                        return inner;
                    }

                    outarray.Add(inner);
                }

                objectlist.Pop();
                return outarray;
            }
            else if (typeof(System.Collections.IDictionary).IsAssignableFrom(tt))       // if its a Dictionary<x,y> then expect a set of objects
            {
                System.Collections.IDictionary idict = o as System.Collections.IDictionary;

                JObject outobj = new JObject();

                objectlist.Push(o);

                foreach (dynamic kvp in idict)      // need dynamic since don't know the types of Value or Key
                {
                    if (objectlist.Contains(kvp.Value))   // self reference
                    {
                        if (ignoreunserialisable)       // if ignoring this, just continue with the next one
                            continue;

                        objectlist.Pop();
                        return new JToken(TType.Error, "Self Reference in IDictionary");
                    }

                    JToken inner = FromObjectInt(kvp.Value, ignoreunserialisable, ignored, objectlist,lvl+1, maxrecursiondepth, membersearchflags);
                    if (inner.IsInError)      // used as an error type
                    {
                        objectlist.Pop();
                        return inner;
                    }

                    if ( kvp.Key is DateTime)               // handle date time specially, use zulu format
                    {
                        DateTime t = (DateTime)kvp.Key;
                        outobj[t.ToStringZulu()] = inner;
                    }
                    else
                        outobj[kvp.Key.ToString()] = inner;
                }

                objectlist.Pop();
                return outobj;
            }
            else if ( (tt.IsClass && tt != typeof(string)) ||                           // if class, but not string (handled in CreateToken)
                      (tt.IsValueType && !tt.IsPrimitive && !tt.IsEnum && tt != typeof(DateTime))     // if value type, not primitive, not enum, its a structure. Not datetime (handled in CreateToken)
                      )
            {
                JObject outobj = new JObject();

                var allmembers = tt.GetMembers(membersearchflags);

                objectlist.Push(o);

                foreach (var mi in allmembers)
                {
                    Type innertype = null;

                    if (mi.MemberType == System.Reflection.MemberTypes.Property)
                        innertype = ((System.Reflection.PropertyInfo)mi).PropertyType;
                    else if (mi.MemberType == System.Reflection.MemberTypes.Field)
                    {
                        var fi = (System.Reflection.FieldInfo)mi;
                        innertype = fi.FieldType;
                    }
                    else
                        continue;

                    if (ignored != null && Array.IndexOf(ignored, innertype) >= 0)
                        continue;

                    var ca = mi.GetCustomAttributes(typeof(JsonIgnoreAttribute), false);
                    if (ca.Length > 0)                                              // ignore any ones with JsonIgnore on it.
                        continue;

                    string attrname = mi.Name;

                    var rename = mi.GetCustomAttributes(typeof(JsonNameAttribute), false);
                    if (rename.Length == 1)                                         // any ones with a rename, use that name     
                    {
                        dynamic attr = rename[0];                                   // dynamic since compiler does not know rename type
                        attrname = attr.Names[0];                                   // only first entry is used for FromObject
                    }

                    //System.Diagnostics.Debug.WriteLine("Member " + mi.Name + " " + mi.MemberType + " attrname " + attrname);

                    Object innervalue = null;
                    if (mi.MemberType == System.Reflection.MemberTypes.Property)
                        innervalue = ((System.Reflection.PropertyInfo)mi).GetValue(o);
                    else 
                        innervalue = ((System.Reflection.FieldInfo)mi).GetValue(o);

                    if ( innervalue != null )
                    {
                        if (objectlist.Contains(innervalue))        // self reference
                        {
                            if (ignoreunserialisable)               // if ignoring this, just continue with the next one
                                continue;

                            objectlist.Pop();
                            return new JToken(TType.Error, "Self Reference by " + tt.Name + ":" + mi.Name );
                        }

                        var token = FromObjectInt(innervalue, ignoreunserialisable, ignored, objectlist, lvl+1, maxrecursiondepth, membersearchflags);     // may return End Object if not serializable

                        if (token.IsInError)
                        {
                            if (!ignoreunserialisable)
                            {
                                objectlist.Pop();
                                return token;
                            }
                        }
                        else
                            outobj[attrname] = token;
                    }
                    else
                    {
                        outobj[attrname] = JToken.Null();        // its null so its a JNull
                    }
                }

                objectlist.Pop();
                return outobj;
            }
            else
            {
                var r = JToken.CreateToken(o, false);        // return token or null indicating unserializable
                                                             //                return r ?? new JToken(TType.Error, "Unserializable " + tt.Name);
                return r ?? new JToken(TType.Error, "Unserializable " + tt.Name);
            }
        }


    }
}



