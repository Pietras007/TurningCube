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

        private Thread SimulationThread = null;
        private InitialConditionsData temporaryConditionsData = new InitialConditionsData();

        private Shader _shaderLight;
        private Shader _shader;
        private Camera _camera;
        private bool cameraLight = true;

        private XyzLines xyzLines = new XyzLines();
        private Cube cube = new Cube();
        private Plane plane = new Plane();
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

        private void displayCubeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.displayCube = displayCubeCheckBox.Checked;
        }

        private void displayWallsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.displayWalls = displayWallsCheckBox.Checked;
        }

        private void displayDiagonalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.displayDiagonal = displayDiagonalCheckBox.Checked;
        }

        private void displayPathCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.displayPath = displayPathCheckBox.Checked;
        }

        private void displayPlaneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.displayPlane = displayPlaneCheckBox.Checked;
        }

        private void pathLengthUpDown_ValueChanged(object sender, EventArgs e)
        {
            globalPhysicsData.numberOfPointsToShow = (int)pathLengthUpDown.Value;
        }

        private void gravityOnCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            globalPhysicsData.gravityOn = gravityOnCheckBox.Checked;
        }

        private void startSimulationButton_Click(object sender, EventArgs e)
        {
            endSimulationButton.Enabled = true;
            startSimulationButton.Enabled = false;
            if (SimulationThread != null)
            {
                SimulationThread.Abort();
            }

            this.GlobalCalculationFunction();
        }

        private void endSimulationButton_Click(object sender, EventArgs e)
        {
            endSimulationButton.Enabled = false;
            startSimulationButton.Enabled = true;
            if (SimulationThread != null)
            {
                SimulationThread.Abort();
            }
        }

        private void applyConditionsButton_Click(object sender, EventArgs e)
        {
            globalPhysicsData.InitialConditionsData = temporaryConditionsData;
            temporaryConditionsData = new InitialConditionsData();
            temporaryConditionsData.cubeEdgeLength = cubeEdgeLengthNumericUpDown.Value;
            temporaryConditionsData.cubeDensity = cubeDensityNumericUpDown.Value;
            temporaryConditionsData.cubeDeviation = cubeDeviationNumericUpDown.Value;
            temporaryConditionsData.angularVelocity = angularVelocityNumericUpDown.Value;
            temporaryConditionsData.integrationStep = integrationStepNumericUpDown.Value;
        }

        private void cubeEdgeLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeEdgeLength = cubeEdgeLengthNumericUpDown.Value;
        }

        private void cubeDensityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeDensity = cubeDensityNumericUpDown.Value;
        }

        private void cubeDeviationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeDeviation = cubeDeviationNumericUpDown.Value;
        }

        private void angularVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.angularVelocity = angularVelocityNumericUpDown.Value;
        }

        private void integrationStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.integrationStep = integrationStepNumericUpDown.Value;
        }

        private void GlobalCalculationFunction()
        {
            SimulationThread = new Thread(() =>
            {
                //Tutaj kod symulacji
            });

            SimulationThread.Start();
        }
    }
}
