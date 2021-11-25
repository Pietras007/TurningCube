using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL4;
using Geometric2.MatrixHelpers;
using Geometric2.ModelGeneration;
using System.Numerics;
using OpenTK;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using Geometric2.Global;
using Geometric2.RasterizationClasses;
using System.Collections.Generic;
using Geometric2.Helpers;

namespace Geometric2
{
    public partial class Form1 : Form
    {
        private void Generate()
        {
            var topPoint = new Vector3(0, (float)Math.Sqrt(3), 0);
            diagonalLine.IsDiagonalLine = true;
            diagonalLine.linePointsList = new List<Vector3>() { new Vector3(0, 0, 0), topPoint };

            List<Vector3> cubeLinePoints = new List<Vector3>()
            {
                new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0.5f, -0.5f, 0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),new Vector3(0.5f, 0.5f, 0.5f),
                new Vector3(0.5f, 0.5f, 0.5f),new Vector3(-0.5f, 0.5f, 0.5f),
                new Vector3(-0.5f, 0.5f, 0.5f),new Vector3(-0.5f, -0.5f, 0.5f),

                new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, -0.5f),new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, 0.5f, -0.5f),new Vector3(-0.5f, 0.5f, -0.5f),
                new Vector3(-0.5f, 0.5f, -0.5f),new Vector3(-0.5f, -0.5f, -0.5f),

                new Vector3(-0.5f, 0.5f, 0.5f),new Vector3(-0.5f, 0.5f, -0.5f),
                new Vector3(0.5f, 0.5f, 0.5f),new Vector3(0.5f, 0.5f, -0.5f),
                new Vector3(-0.5f, -0.5f, 0.5f),new Vector3(-0.5f, -0.5f, -0.5f),
                new Vector3(0.5f, -0.5f, 0.5f),new Vector3(0.5f, -0.5f, -0.5f),
            };

            var modelMtxPoints = ModelMatrix.CreateModelMatrix(1.0f, (float)Math.PI / 4, 0.0f, (float)Math.Atan(Math.Sqrt(2) / 2), new Vector3(0, (float)Math.Sqrt(3) / 2, 0));
            foreach (var p in cubeLinePoints)
            {
                cubeLines.linePointsList.Add(new Vector3(new Vector4(p, 1.0f) * modelMtxPoints));
            }

            pathLines.IsMoveLine = true;
            var topPointInModelSpace = new Vector4(topPoint, 1.0f) * CreateModelMatrix.CreateMatrixForPoint(globalPhysicsData);
            for (int i = 0; i < 1000000; i++)
            {
                pathLines.linePointsList.Add(new Vector3(topPointInModelSpace));
            }
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            Generate();
            Elements.Add(xyzLines);
            Elements.Add(plane);
            Elements.Add(diagonalLine);
            Elements.Add(cubeLines);
            Elements.Add(cube);
            Elements.Add(pathLines);
            GL.ClearColor(Color.LightCyan);
            GL.Enable(EnableCap.DepthTest);
            _shader = new Shader("./../../../Shaders/VertexShaderLines.vert", "./../../../Shaders/FragmentShaderLines.frag");
            _shaderLight = new Shader("./../../../Shaders/VertexShader.vert", "./../../../Shaders/FragmentShader.frag");


            foreach (var el in Elements)
            {
                el.CreateGlElement(_shader, _shaderLight);
            }

            _camera = new Camera(new Vector3(0, 5, 15), glControl1.Width / (float)glControl1.Height);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 viewMatrix = _camera.GetViewMatrix();
            Matrix4 projectionMatrix = _camera.GetProjectionMatrix();

            RenderScene(viewMatrix, projectionMatrix);

            GL.Flush();
            glControl1.SwapBuffers();
        }

        private void RenderScene(Matrix4 viewMatrix, Matrix4 projectionMatrix)
        {
            _shader.Use();
            _shader.SetMatrix4("view", viewMatrix);
            _shader.SetMatrix4("projection", projectionMatrix);
            _shader.SetVector3("fragmentColor", ColorHelper.ColorToVector(Color.Black));

            _shaderLight.Use();
            _shaderLight.SetMatrix4("view", viewMatrix);
            _shaderLight.SetMatrix4("projection", projectionMatrix);
            var camPos = _camera.GetCameraPosition();
            _shaderLight.SetVector3("viewPos", camPos);

            _shaderLight.SetInt("material.diffuse", 0);
            _shaderLight.SetInt("material.specular", 1);
            _shaderLight.SetInt("material.noise", 2);
            _shaderLight.SetFloat("material.shininess", 16.0f);
            if (cameraLight)
            {
                _shaderLight.SetVector3("light.position", camPos);
            }
            else
            {
                _shaderLight.SetVector3("light.position", new Vector3(5, 25, 5));
            }
            _shaderLight.SetVector3("light.ambient", new Vector3(0.3f, 0.3f, 0.3f));
            _shaderLight.SetVector3("light.diffuse", new Vector3(0.5f, 0.5f, 0.5f));
            _shaderLight.SetVector3("light.specular", new Vector3(0.3f, 0.3f, 0.3f));


            foreach (var el in Elements)
            {

                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                el.RenderGlElement(_shader, _shaderLight, new Vector3(0, 0, 0), globalPhysicsData);
            }

        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            int xPosMouse, yPosMouse;
            if (e.Button == MouseButtons.Middle)
            {
                xPosMouse = e.X;
                yPosMouse = e.Y;
                if (prev_xPosMouse != -1 && prev_yPosMouse != -1)
                {
                    var deltaX = xPosMouse - prev_xPosMouse;
                    var deltaY = yPosMouse - prev_yPosMouse;

                    _camera.RotationX -= (float)(2 * Math.PI * deltaY / glControl1.Height);
                    _camera.RotationY += (float)(2 * Math.PI * deltaX / glControl1.Width);

                }

                prev_xPosMouse = xPosMouse;
                prev_yPosMouse = yPosMouse;
            }
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
            {
                prev_xPosMouse = -1;
                prev_yPosMouse = -1;
            }
        }

        private void glControl1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 200;
            if (_camera.CameraDist - numberOfTextLinesToMove > 1.0f)
            {
                _camera.CameraDist -= numberOfTextLinesToMove;
            }
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        }

        private void glControl1_KeyUp(object sender, KeyEventArgs e)
        {
        }
    }
}
