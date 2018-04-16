using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDD3D.Colors;
using EDD3D.Maths;
using EDD3D.Chart;
using EDD3D.Chart.Controllers.Thread.Camera;
using EDD3D.Chart.Controllers.Mouse.Camera;
using EDD3D.Plot3D.Primitives;
using EDD3D.Plot3D.Primitives.Axes;
using EDD3D.Plot3D.Primitives.Axes.Layout;
using EDD3D.Plot3D.Rendering.Canvas;
using EDD3D.Plot3D.Rendering.View;
using EDD3D.Plot3D.Rendering.View.Modes;

namespace Demos
{
    public partial class ScatterDemo : Form
    {
        private CameraThreadController t;
        private IAxeLayout axeLayout;
        private Chart _chart;

        public ScatterDemo()
        {
            InitializeComponent();
        }

        private void InitScatter()
        {
            int size = 10000;
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

            Scatter scatter = new Scatter(points, colors, Width = 5);
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
            chart.View.Squared = true; // maintain the map squared when zoomed 

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

        private void comboBox1_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "FREE")
            {
                renderer3D1.View.ViewMode = ViewPositionMode.FREE; // enable free rotation, in all three axes
            }
            if (comboBox1.Text == "PROFILE")
            {
                renderer3D1.View.ViewMode = ViewPositionMode.PROFILE; // enable free rotation, in all three axes
            }
            if (comboBox1.Text == "TOP")
            {
                renderer3D1.View.ViewMode = ViewPositionMode.TOP; // enable free rotation, in all three axes
            }
            if (comboBox1.Text == "FRONT")
            {
                renderer3D1.View.ViewMode = ViewPositionMode.FRONT; // enable free rotation, in all three axes
            }
        }

        private void renderer3D1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0)
            {
                
            }

            if (e.KeyCode == Keys.NumPad1)
            {
                
            }

            if (e.KeyCode == Keys.NumPad2)
            {
                
            }

            if (e.KeyCode == Keys.NumPad3)
            {
                
            }

            if (e.KeyCode == Keys.Up)
            {
                // turn up
                renderer3D1.View.setViewPoint(new Coord3d(+0, +50, +0), true);
            }

            if (e.KeyCode == Keys.Down)
            {
                // turn down
                renderer3D1.View.setViewPoint(new Coord3d(+0, -50, +0), true);
            }

            if (e.KeyCode == Keys.Left)
            {
                // turn right
                renderer3D1.View.setViewPoint(new Coord3d(+50, +0, +0), true);
            }

            if (e.KeyCode == Keys.Right)
            {
                // turn left
                renderer3D1.View.setViewPoint(new Coord3d(-50, +0, +0), true);
            }

        }

        private void buttonQuarter_Click(object sender, EventArgs e)
        {
            // three quarter view
            renderer3D1.View.setViewPoint(new Coord3d(Math.PI / 3, Math.PI / 3, 0), true);
        }

        private void buttonFront_Click(object sender, EventArgs e)
        {
            // front view
            renderer3D1.View.setViewPoint(new Coord3d(0, 0, 0), true);
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            // top view
            renderer3D1.View.setViewPoint(new Coord3d(0, Math.PI, 0), true);
        }

        private void buttonBottom_Click(object sender, EventArgs e)
        {
            // bottom view
            renderer3D1.View.setViewPoint(new Coord3d(0, -Math.PI, 0), true);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            // right view
            renderer3D1.View.setViewPoint(new Coord3d(Math.PI / 2, 0, 0), true);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            // right view
            renderer3D1.View.setViewPoint(new Coord3d(-Math.PI / 2, 0, 0), true);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // back view
            renderer3D1.View.setViewPoint(new Coord3d(Math.PI, 0, 0), true);
        }
    }    
}
