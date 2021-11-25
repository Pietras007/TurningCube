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
        public List<Vector3> linePoints = new List<Vector3>();
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

            var diagonalRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.diagonalRoundInRadian, 0))).Normalized();
            var xRoundQ = (new Quaternion(new Vector3((float)globalPhysicsData.alfaAngleInRadian, 0, 0))).Normalized();
            var yRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.yRoundInRadian, 0))).Normalized();
            RotationQuaternion = yRoundQ * xRoundQ * diagonalRoundQ;

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
                    _shader.SetMatrix4("model", Matrix4.Identity);
                    GenerateLines();
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

        private void GenerateLines()
        {
            var tempLinesPoints = new float[3 * linePoints.Count];
            var tempLinesIndices = new uint[linePoints.Count];
            int idx = 0;
            var tempLinePointsReference = linePoints;
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
    }
}
