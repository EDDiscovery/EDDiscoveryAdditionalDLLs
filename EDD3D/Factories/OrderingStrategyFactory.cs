
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using EDD3D.Plot3D.Rendering.Ordering;

namespace EDD3D.Factories
{

	public class OrderingStrategyFactory
	{

		public static AbstractOrderingStrategy getInstance()
		{
			return DEFAULTORDERING;
		}


		public static BarycentreOrderingStrategy DEFAULTORDERING = new BarycentreOrderingStrategy();
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
