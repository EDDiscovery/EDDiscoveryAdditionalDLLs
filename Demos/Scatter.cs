using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDD3D;
using EDD3D.Colors;
using EDD3D.Maths;
using EDD3D.Chart.Controllers.Thread.Camera;
using EDD3D.Chart.Controllers.Mouse.Camera;
using EDD3D.Plot3D.Primitives;
using EDD3D.Plot3D.Primitives.Axes;
using EDD3D.Plot3D.Primitives.Axes.Layout;
using EDD3D.Plot3D.Rendering.Canvas;
using EDD3D.Plot3D.Rendering.View;
using EDD3D.Plot3D.Rendering.View.Modes;
using EDD3D.Chart;

namespace Demos
{
    public partial class ScatterChart : Form
    {
        private CameraThreadController t;
        private IAxeLayout axeLayout;

        public ScatterChart()
        {
            InitializeComponent();
        }

        private void InitScatter()
        {
            int size = 1000;
            double x;
            double y;
            double z;
            double c;

            Coord3d[] points = new Coord3d[size];
            Color[] colors = new Color[size];

            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                x = r.NextDouble();
                y = r.NextDouble();
                z = r.NextDouble();
                c = r.NextDouble();
                points[i] = new Coord3d(x, y, z);
                colors[i] = new Color(x, y, z, c);
            }

            // Create the chart and embed the scatter within
            Chart chart = new Chart(renderer3D1, Quality.Nicest);
            axeLayout = chart.AxeLayout;

            Scatter scatter = new Scatter(points, colors, Width = 10);
            chart.Scene.Graph.Add(scatter);

            // Create a mouse control
            CameraMouseController mouse = new CameraMouseController();
            mouse.addControllerEventListener(renderer3D1);
            chart.addController(mouse);

            // This is just to ensure code is reentrant (used when code is not called in Form_Load but another reentrant event)
            DisposeBackgroundThread();

            // Create a thread to control the camera based on mouse movements
            t = new CameraThreadController();
            t.addControllerEventListener(renderer3D1);
            mouse.addSlaveThreadController(t);
            chart.addController(t);
            t.Start();

            // Associate the chart with current control
            renderer3D1.setView(chart.View);

            // show axes
            chart.View.AxeBoxDisplayed = true;

            // view 
            //chart.View.Squared = true; // maintain the map squared when zoomed 

            // default view mode
            chart.View.ViewMode = ViewPositionMode.FREE; // enable free rotation, in all three axes

            // default camera mode
            chart.View.CameraMode = CameraMode.PERSPECTIVE; // it give the viewport a slight perspective

            // debug grid
            chart.View.Camera.ScreenGridDisplayed = false;       

            // axes labels
            chart.AxeLayout.XAxeLabel = "X";
            chart.AxeLayout.YAxeLabel = "Y";
            chart.AxeLayout.ZAxeLabel = "Z";

            // background color
            chart.View.BackgroundColor = Color.BLACK;

            // axes color
            chart.AxeLayout.MainColor = Color.WHITE;
            chart.AxeLayout.GridColor = Color.GRAY;

            this.Refresh();
        }

        private void DisposeBackgroundThread()
        {
            if ((t != null))
            {
                t.Dispose();
            }
        }

        private void renderer3D1_Load(object sender, EventArgs e)
        {
            InitScatter();
        }

        private void ScatterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeBackgroundThread();
        }
    }    
}
