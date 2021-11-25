using Geometric2.Global;
using Geometric2.MatrixHelpers;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric2.Helpers
{
    public static class CreateModelMatrixForPoint
    {
        public static Matrix4 CreateMatrix(GlobalPhysicsData globalPhysicsData)
        {
            var diagonalRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.diagonalRoundInRadian, 0))).Normalized();
            var xRoundQ = (new Quaternion(new Vector3((float)globalPhysicsData.alfaAngleInRadian, 0, 0))).Normalized();
            var yRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.yRoundInRadian, 0))).Normalized();
            var RotationQuaternion = yRoundQ * xRoundQ * diagonalRoundQ;
            var cubeSize = (float)globalPhysicsData.InitialConditionsData.cubeEdgeLength;
            Matrix4 model = ModelMatrix.CreateModelMatrix(new Vector3(cubeSize, cubeSize, cubeSize), RotationQuaternion, new Vector3(0, 0, 0), new Vector3(0, 0, 0), Quaternion.FromEulerAngles(0.0f, 0.0f, 0.0f));
            return model;
        }
    }
}
