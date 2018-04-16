using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDD3D.Chart;
using EDD3D.Chart.Controllers.Thread.Camera;
using EDD3D.Chart.Controllers.Mouse.Camera;
using EDD3D.Colors;
using EDD3D.Colors.ColorMaps;
using EDD3D.Maths;
using EDD3D.Plot3D.Builder;
using EDD3D.Plot3D.Builder.Concrete;
using EDD3D.Plot3D.Primitives;
using EDD3D.Plot3D.Primitives.Axes;
using EDD3D.Plot3D.Primitives.Axes.Layout;
using EDD3D.Plot3D.Rendering.Canvas;
using EDD3D.Plot3D.Rendering.View;


namespace Demos
{
    public partial class Example : Form
    {

        private CameraThreadController t;
        private IAxeLayout axeLayout;

        public Example()
        {
            InitializeComponent();
        }

        private void InitRenderer()
        {

            // Create the Renderer 3D control.
            //Renderer3D myRenderer3D = new Renderer3D();

            // Add the Renderer control to the panel
            // mainPanel.Controls.Clear();
            //mainPanel.Controls.Add(myRenderer3D);

            // Create a range for the graph generation
            Range range = new Range(-150, 150);
            int steps = 50;

            // Build a nice surface to display with cool alpha colors 
            // (alpha 0.8 for surface color and 0.5 for wireframe)
            Shape surface = Builder.buildOrthonomal(new OrthonormalGrid(range, steps, range, steps), new MyMapper());
            surface.ColorMapper = new ColorMapper(new ColorMapRainbow(), surface.Bounds.zmin, surface.Bounds.zmax, new Color(1, 1, 1, 0.8));
            surface.FaceDisplayed = true;
            surface.WireframeDisplayed = true;
            surface.WireframeColor = Color.CYAN;
            surface.WireframeColor.mul(new Color(1, 1, 1, 0.5));

            // Create the chart and embed the surface within
            Chart chart = new Chart(renderer3D1, Quality.Nicest);
            chart.Scene.Graph.Add(surface);
            axeLayout = chart.AxeLayout;

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

            this.Refresh();
        }

        class MyMapper : EDD3D.Plot3D.Builder.Mapper
        {

            public override double f(double x, double y)
            {
                return 10 * Math.Sin(x / 10) * Math.Cos(y / 20) * x;
            }

        }

        private void DisposeBackgroundThread()
        {
            if ((t != null))
            {
                t.Dispose();
            }
        }

        private void Example_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeBackgroundThread();
        }

        private void renderer3D1_Load(object sender, EventArgs e)
        {
            InitRenderer();
        }
    }
}
