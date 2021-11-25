using System;
using System.Collections.Generic;
using System.Drawing;
using Geometric2.Global;
using Geometric2.Helpers;
using Geometric2.MatrixHelpers;
using Geometric2.RasterizationClasses;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Geometric2.ModelGeneration
{
    public class Lines : Element
    {
        public bool IsDiagonalLine { get; set; }
        public bool IsMoveLine { get; set; }
        public List<Vector3> linePointsList = new List<Vector3>();
        float[] linesPoints = new float[] { };
        uint[] linesIndices = new uint[] { };
        int linesVBO, linesVAO, linesEBO;


        public override void CreateGlElement(Shader _shader, Shader _shaderLight)
        {
            GenerateLines();
            _shader.Use();
            var a_Position_Location = _shader.GetAttribLocation("a_Position");
            linesVAO = GL.GenVertexArray();
            linesVBO = GL.GenBuffer();
            linesEBO = GL.GenBuffer();
            GL.BindVertexArray(linesVAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, linesVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, linesPoints.Length * sizeof(float), linesPoints, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, linesEBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, linesIndices.Length * sizeof(uint), linesIndices, BufferUsageHint.DynamicDraw);
            GL.VertexAttribPointer(a_Position_Location, 3, VertexAttribPointerType.Float, true, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(a_Position_Location);
        }

        public override void RenderGlElement(Shader _shader, Shader _shaderLight, Vector3 rotationCentre, GlobalPhysicsData globalPhysicsData)
        {
            RotationQuaternion = CreateModelMatrix.GetQuaternionFromPhysicsData(globalPhysicsData);

            _shader.Use();
            var cubeSize = (float)globalPhysicsData.InitialConditionsData.cubeEdgeLength;
            Matrix4 model = ModelMatrix.CreateModelMatrix(new Vector3(cubeSize, cubeSize, cubeSize), RotationQuaternion, CenterPosition + Translation, rotationCentre, TempRotationQuaternion);
            _shader.SetMatrix4("model", model);
            GL.BindVertexArray(linesVAO);
            if (IsDiagonalLine)
            {
                if (globalPhysicsData.displayDiagonal)
                {
                    GenerateLines();
                    _shader.SetVector3("fragmentColor", ColorHelper.ColorToVector(Color.Purple));
                    GL.DrawElements(PrimitiveType.Lines, linesIndices.Length, DrawElementsType.UnsignedInt, 0 * sizeof(int));
                }
            }
            else if (IsMoveLine)
            {
                if (globalPhysicsData.displayPath)
                {
                    FillLineGeometry();
                    _shader.SetMatrix4("model", Matrix4.Identity);
                    GenerateLinesForPath(globalPhysicsData);
                    _shader.SetVector3("fragmentColor", ColorHelper.ColorToVector(Color.Black));
                    GL.DrawElements(PrimitiveType.LineStrip, linesIndices.Length, DrawElementsType.UnsignedInt, 0 * sizeof(int));
                }
            }
            else
            {
                if (globalPhysicsData.displayCube)
                {
                    GenerateLines();
                    _shader.SetVector3("fragmentColor", ColorHelper.ColorToVector(Color.Black));
                    GL.DrawElements(PrimitiveType.Lines, linesIndices.Length, DrawElementsType.UnsignedInt, 0 * sizeof(int));
                }
            }

            GL.BindVertexArray(0);
        }

        private void FillLineGeometry()
        {
            GL.BindVertexArray(linesVAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, linesVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, linesPoints.Length * sizeof(float), linesPoints, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, linesEBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, linesIndices.Length * sizeof(uint), linesIndices, BufferUsageHint.DynamicDraw);
        }

        private void GenerateLines()
        {
            var tempLinesPoints = new float[3 * linePointsList.Count];
            var tempLinesIndices = new uint[linePointsList.Count];
            int idx = 0;
            var tempLinePointsReference = linePointsList;
            foreach (var p in tempLinePointsReference)
            {
                tempLinesPoints[3 * idx] = p.X;
                tempLinesPoints[3 * idx + 1] = p.Y;
                tempLinesPoints[3 * idx + 2] = p.Z;
                tempLinesIndices[idx] = (uint)idx;
                idx++;
            }

            linesPoints = tempLinesPoints;
            linesIndices = tempLinesIndices;
        }

        private void GenerateLinesForPath(GlobalPhysicsData globalPhysicsData)
        {
            var tempLinesPoints = new float[linesPoints.Length];
            var tempLinesIndices = new uint[globalPhysicsData.numberOfPointsToShow];

            lock (globalPhysicsData.lockPathPointsList)
            {
                int pointsInList = linePointsList.Count;
                int allAvailablePoints = linesPoints.Length / 3;
                for (int i = 0; i < allAvailablePoints; i++)
                {
                    int offset = pointsInList - allAvailablePoints;
                    tempLinesPoints[3 * i] = linePointsList[offset + i].X;
                    tempLinesPoints[3 * i + 1] = linePointsList[offset + i].Y;
                    tempLinesPoints[3 * i + 2] = linePointsList[offset + i].Z;
                }

                int idx = 0;
                for (int i = allAvailablePoints - globalPhysicsData.numberOfPointsToShow; i < allAvailablePoints; i++)
                {
                    tempLinesIndices[idx] = (uint)i;
                    idx++;
                }
            }

            linesPoints = tempLinesPoints;
            linesIndices = tempLinesIndices;
        }
    }
}
