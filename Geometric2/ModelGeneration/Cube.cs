using System;
using System.Drawing;
using Geometric2.Global;
using Geometric2.Helpers;
using Geometric2.MatrixHelpers;
using Geometric2.Models;
using Geometric2.RasterizationClasses;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Geometric2.ModelGeneration
{
    public class Cube : Element
    {
        private float[] cubePoints = {
             // Positions          Normals              Texture coords
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f,  0.0f, 0.0f,

            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
            -0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f,  1.0f, 0.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f
        };

        public int cubeVBO, cubeVAO, cubeEBO;
        uint[] indices;
        Texture texture;
        Texture specular;
        Texture noise;
        float diagonalRoundInRadian = 0;
        float yRoundInRadian = 0;
        public CubeData CubeData { get; set; }

        public Cube()
        {
            indices = new uint[36];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = (uint)i;
            }
        }

        public override void CreateGlElement(Shader _shader, Shader _shaderLight)
        {
            cubePoints = ChangePointAndNormalsPositions(cubePoints);
            _shaderLight.Use();
            texture = new Texture("./../../../Resources/wood.jpg");
            specular = new Texture("./../../../Resources/50specular.png");
            noise = new Texture("./../../../Resources/noise.jpg");
            cubeVAO = GL.GenVertexArray();
            cubeVBO = GL.GenBuffer();
            cubeEBO = GL.GenBuffer();
            GL.BindVertexArray(cubeVAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, cubeVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, cubePoints.Length * sizeof(float), cubePoints, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, cubeEBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);
            var a_Position_Location = _shaderLight.GetAttribLocation("a_Position");
            GL.VertexAttribPointer(a_Position_Location, 3, VertexAttribPointerType.Float, true, 8 * sizeof(float), 0);
            GL.EnableVertexAttribArray(a_Position_Location);
            var aNormal = _shaderLight.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(aNormal);
            GL.VertexAttribPointer(aNormal, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
            var aTexCoords = _shaderLight.GetAttribLocation("aTexCoords");
            GL.EnableVertexAttribArray(aTexCoords);
            GL.VertexAttribPointer(aTexCoords, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
        }

        public override void RenderGlElement(Shader _shader, Shader _shaderLight, Vector3 rotationCentre, GlobalPhysicsData globalPhysicsData)
        {
            if (globalPhysicsData.displayWalls)
            {
                _shaderLight.Use();

                RotationQuaternion = CreateModelMatrix.GetQuaternionFromPhysicsData(globalPhysicsData);
                var cubeSize = (float)globalPhysicsData.InitialConditionsData.cubeEdgeLength;
                Matrix4 model = ModelMatrix.CreateModelMatrix(new Vector3(cubeSize, cubeSize, cubeSize), RotationQuaternion, CenterPosition + Translation, rotationCentre, TempRotationQuaternion);
                _shaderLight.SetMatrix4("model", model);
                _shaderLight.SetInt("transparent", 1);
                GL.BindVertexArray(cubeVAO);
                texture.Use();
                specular.Use(TextureUnit.Texture1);
                noise.Use(TextureUnit.Texture2);
                GL.DrawElements(PrimitiveType.Triangles, cubePoints.Length, DrawElementsType.UnsignedInt, 0);
                GL.BindVertexArray(0);
            }
        }

        private float[] ChangePointAndNormalsPositions(float[] pointsNormalsTextCoords)
        {
            float[] result = new float[pointsNormalsTextCoords.Length];
            for (int i = 0; i < pointsNormalsTextCoords.Length; i += 8)
            {
                var modelMtxPoints = ModelMatrix.CreateModelMatrix(1.0f, (float)Math.PI / 4, 0.0f, (float)Math.Atan(Math.Sqrt(2) / 2), new Vector3(0, (float)Math.Sqrt(3) / 2, 0));
                var modelMtxNormals = ModelMatrix.CreateModelMatrix(1.0f, (float)Math.PI / 4, 0.0f, (float)Math.Atan(Math.Sqrt(2) / 2), new Vector3(0, 0, 0));

                Vector4 position = new Vector4(pointsNormalsTextCoords[i], pointsNormalsTextCoords[i + 1], pointsNormalsTextCoords[i + 2], 1.0f);
                Vector4 normal = new Vector4(pointsNormalsTextCoords[i + 3], pointsNormalsTextCoords[i + 4], pointsNormalsTextCoords[i + 5], 1.0f);

                position = position * modelMtxPoints;
                normal = normal * modelMtxNormals;

                result[i] = position.X;
                result[i + 1] = position.Y;
                result[i + 2] = position.Z;

                result[i + 3] = normal.X;
                result[i + 4] = normal.Y;
                result[i + 5] = normal.Z;

                result[i + 6] = pointsNormalsTextCoords[i + 6];
                result[i + 7] = pointsNormalsTextCoords[i + 7];
            }

            return result;
        }
    }
}
