using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometric2.RasterizationClasses;
using OpenTK.Graphics.OpenGL4;
using Geometric2.MatrixHelpers;
using Geometric2.ModelGeneration;
using System.Numerics;
using OpenTK;
using Geometric2.Helpers;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using Geometric2.Global;
using System.Xml;
using System.Linq;
using Geometric2.Models;

namespace Geometric2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    glControl1.Invalidate();
                    Thread.Sleep(16);
                }
            });

            thread.Start();
            this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseWheel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cameraLightCheckBox.Checked = true;
        }

        private Shader _shaderLight;
        private Shader _shader;
        private Camera _camera;
        private bool cameraLight = true;

        private XyzLines xyzLines = new XyzLines();
        private Cube cube = new Cube();
        private List<Element> Elements = new List<Element>();
        private Lines diagonalLine = new Lines();
        private Lines cubeLines = new Lines();

        int prev_xPosMouse = -1, prev_yPosMouse = -1;
        GlobalPhysicsData globalPhysicsData = new GlobalPhysicsData();

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cameraLightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cameraLight = cameraLightCheckBox.Checked;
        }

        private void GlobalCalculationFunction()
        {

        }
    }
}
