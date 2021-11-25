using Geometric2.Global;
using Geometric2.MatrixHelpers;
using OpenTK;

namespace Geometric2.Helpers
{
    public static class CreateModelMatrix
    {
        public static Matrix4 CreateMatrixForPoint(GlobalPhysicsData globalPhysicsData)
        {
            //var diagonalRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.diagonalRoundInRadian, 0))).Normalized();
            //var xRoundQ = (new Quaternion(new Vector3((float)globalPhysicsData.alfaAngleInRadian, 0, 0))).Normalized();
            //var yRoundQ = (new Quaternion(new Vector3(0, (float)globalPhysicsData.yRoundInRadian, 0))).Normalized();
            //var RotationQuaternion = yRoundQ * xRoundQ * diagonalRoundQ;

            var rotationQuaternion = GetQuaternionFromPhysicsData(globalPhysicsData);
            var cubeSize = (float)globalPhysicsData.InitialConditionsData.cubeEdgeLength;
            Matrix4 model = ModelMatrix.CreateModelMatrix(new Vector3(cubeSize, cubeSize, cubeSize), rotationQuaternion, new Vector3(0, 0, 0), new Vector3(0, 0, 0), Quaternion.FromEulerAngles(0.0f, 0.0f, 0.0f));
            return model;
        }

        public static Quaternion GetQuaternionFromPhysicsData(GlobalPhysicsData globalPhysicsData)
        {
            var diagonalRoundQ = Quaternion.FromEulerAngles((float)globalPhysicsData.diagonalRoundInRadianX, (float)globalPhysicsData.diagonalRoundInRadianY, (float)globalPhysicsData.diagonalRoundInRadianZ).Normalized();
            var rotationQuaternion = globalPhysicsData.rotationQuaternion;
            return rotationQuaternion * diagonalRoundQ;
        }
    }
}
