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
    public class Plane : Element
    {
        private float[] planePoints = {
             // Positions          Normals              Texture coords
            -2.0f,  0.0f, -2.0f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
            -2.0f,  0.0f,  2.0f,  0.0f,  1.0f,  0.0f,  1.0f, 0.0f,
             2.0f,  0.0f,  2.0f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
            -2.0f,  0.0f, -2.0f,  0.0f,  1.0f,  0.0f,  0.0f, 0.0f,
             2.0f,  0.0f,  2.0f,  0.0f,  1.0f,  0.0f,  1.0f, 1.0f,
             2.0f,  0.0f, -2.0f,  0.0f,  1.0f,  0.0f,  0.0f, 1.0f,
        };

        public int planeVBO, planeVAO, planeEBO;
        uint[] indices;
        Texture texture;
        Texture specular;
        Texture noise;

        public Plane()
        {
            indices = new uint[6];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = (uint)i;
            }
        }

        public override void CreateGlElement(Shader _shader, Shader _shaderLight)
        {
            _shaderLight.Use();
            texture = new Texture("./../../../Resources/wood.jpg");
            specular = new Texture("./../../../Resources/50specular.png");
            noise = new Texture("./../../../Resources/noise.jpg");
            planeVAO = GL.GenVertexArray();
            planeVBO = GL.GenBuffer();
            planeEBO = GL.GenBuffer();
            GL.BindVertexArray(planeVAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, planeVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, planePoints.Length * sizeof(float), planePoints, BufferUsageHint.DynamicDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, planeEBO);
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
            if (globalPhysicsData.displayPlane)
            {
                var model = ModelMatrix.CreateModelMatrix(1, 0, 0, 0, new Vector3(0, 0, 0));
                _shaderLight.Use();
                //_shaderLight.SetMatrix4("model", Matrix4.Identity);
                _shaderLight.SetMatrix4("model", model);
                _shaderLight.SetInt("transparent", 0);
                GL.BindVertexArray(planeVAO);
                texture.Use();
                specular.Use(TextureUnit.Texture1);
                noise.Use(TextureUnit.Texture2);
                GL.DrawElements(PrimitiveType.Triangles, planePoints.Length, DrawElementsType.UnsignedInt, 0);
                GL.BindVertexArray(0);
            }
        }
    }
}
