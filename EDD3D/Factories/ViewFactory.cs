
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using EDD3D.Plot3D.Rendering.View;
using EDD3D.Plot3D.Rendering.Scene;
using EDD3D.Plot3D.Rendering.Canvas;
using EDD3D.Chart;

namespace EDD3D.Factories
{

	public class ViewFactory
	{

		public static View getInstance(Scene scene, ICanvas canvas, Quality quality)
		{
			return new ChartView(scene, canvas, quality);
		}

	}

}


//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
