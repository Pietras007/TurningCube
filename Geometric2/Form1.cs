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
        private Thread PointListThread = null;
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
        private Lines pathLines = new Lines();

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
            applyConditionsButton.Enabled = false;
            if (SimulationThread != null)
            {
                SimulationThread.Abort();
            }

            if (PointListThread != null)
            {
                PointListThread.Abort();
            }

            this.GlobalCalculationFunction();
            this.DrawPath();
        }

        private void endSimulationButton_Click(object sender, EventArgs e)
        {
            endSimulationButton.Enabled = false;
            startSimulationButton.Enabled = true;
            applyConditionsButton.Enabled = true;
            if (SimulationThread != null)
            {
                SimulationThread.Abort();
            }

            if (PointListThread != null)
            {
                PointListThread.Abort();
            }
        }

        private void applyConditionsButton_Click(object sender, EventArgs e)
        {
            globalPhysicsData.InitialConditionsData = temporaryConditionsData;
            globalPhysicsData.alfaAngleInRadian = (Math.PI / 180) * (double)cubeDeviationNumericUpDown.Value;
            temporaryConditionsData = new InitialConditionsData();
            temporaryConditionsData.cubeEdgeLength = (double)cubeEdgeLengthNumericUpDown.Value;
            temporaryConditionsData.cubeDensity = (double)cubeDensityNumericUpDown.Value;
            temporaryConditionsData.cubeDeviationRadian = (Math.PI / 180) * (double)cubeDeviationNumericUpDown.Value;
            temporaryConditionsData.angularVelocityRadian = (Math.PI / 180) * (double)angularVelocityNumericUpDown.Value;
            temporaryConditionsData.integrationStep = (double)integrationStepNumericUpDown.Value;

        }

        private void cubeEdgeLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeEdgeLength = (double)cubeEdgeLengthNumericUpDown.Value;
        }

        private void cubeDensityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeDensity = (double)cubeDensityNumericUpDown.Value;
        }

        private void cubeDeviationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.cubeDeviationRadian = (Math.PI / 180) * (double)cubeDeviationNumericUpDown.Value;
        }

        private void angularVelocityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.angularVelocityRadian = (Math.PI / 180) * (double)angularVelocityNumericUpDown.Value;
        }

        private void integrationStepNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            temporaryConditionsData.integrationStep = (double)integrationStepNumericUpDown.Value;
        }

        private Vector3d GetInertiaTensor()
        {
            var inertiaTensorBaseX = 11d / 12d;
            var inertiaTensorBaseY = 1d / 6d;
            var inertiaTensorBaseZ = 11d / 12d;

            var edge = globalPhysicsData.InitialConditionsData.cubeEdgeLength;
            var density = globalPhysicsData.InitialConditionsData.cubeDensity;

            return Math.Pow(edge, 5d) * density * new Vector3d(inertiaTensorBaseX, inertiaTensorBaseY, inertiaTensorBaseZ);
        }

        private void GlobalCalculationFunction()
        {
            SimulationThread = new Thread(() =>
            {
                while (true)
                {
                    long nanosecondsToWait = (long)(globalPhysicsData.InitialConditionsData.integrationStep * 1000_1000_1000);
                    long nanoPrev = 10000L * Stopwatch.GetTimestamp();
                    nanoPrev /= TimeSpan.TicksPerMillisecond;
                    nanoPrev *= 100L;


                    //Tutaj kod symulacji co wykonuje się co delta (globalPhysicsData.InitialConditionsData.integrationStep)
                    //Obliczenia
                    //TYLKO STAD BRAĆ DANE DO OBLICZEN  globalPhysicsData. itd dalej



                    //UStawienie odpowiednich wartości dla sześcianu
                    globalPhysicsData.alfaAngleInRadian += 0.000001;
                    globalPhysicsData.diagonalRoundInRadian += 0.001;
                    globalPhysicsData.yRoundInRadian += 0.00001;


                    //Odczekanie pozostałego czasu
                    long nanoPost;
                    while (true)
                    {
                        nanoPost = 10000L * Stopwatch.GetTimestamp();
                        nanoPost /= TimeSpan.TicksPerMillisecond;
                        nanoPost *= 100L;
                        if (nanoPost - nanoPrev > nanosecondsToWait)
                        {
                            break;
                        }
                    }
                }
            });

            SimulationThread.Start();
        }

        private void DrawPath()
        {
            PointListThread = new Thread(() =>
            {
                //pathLines.linePointsList.

                while (true)
                {
                    var topPoint = new Vector3(0, (float)Math.Sqrt(3), 0);
                    var topPointInModelSpace = new Vector4(topPoint, 1.0f) * CreateModelMatrixForPoint.CreateMatrix(globalPhysicsData);
                    pathLines.linePointsList.Add(new Vector3(topPointInModelSpace));
                    Thread.Sleep(10);
                }
            });

            PointListThread.Start();
        }
    }
}
