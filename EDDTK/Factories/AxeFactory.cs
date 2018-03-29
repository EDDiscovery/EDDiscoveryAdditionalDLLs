
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using EDDTK.Maths;
using EDDTK.Plot3D.Primitives.Axes;
using EDDTK.Plot3D.Rendering.View;

namespace EDDTK.Factories
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
