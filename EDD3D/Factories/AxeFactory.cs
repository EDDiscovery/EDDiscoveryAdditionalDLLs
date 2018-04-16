
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using EDD3D.Maths;
using EDD3D.Plot3D.Primitives.Axes;
using EDD3D.Plot3D.Rendering.View;

namespace EDD3D.Factories
{

	public class AxeFactory
	{
		public static object getInstance(BoundingBox3d box, View view)
		{
			AxeBox axe = new AxeBox(box);
			axe.View = view;
			return axe;
		}
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
