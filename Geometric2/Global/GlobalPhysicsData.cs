using OpenTK;
using System;

namespace Geometric2.Global
{
    public class GlobalPhysicsData
    {
        //Help
        public object lockPathPointsList = new object { };

        //Visualization Settings
        public bool displayCube = true;
        public bool displayDiagonal = true;
        public bool displayPath = true;
        public bool displayPlane = true;
        public bool displayWalls = true;
        public int numberOfPointsToShow = 1000;

        //Data from user
        public bool gravityOn = false;
        public InitialConditionsData InitialConditionsData = new InitialConditionsData();

        //Visualization Data
        public double alfaAngleInRadian = (double)(Math.PI / 180) * 15;
        public double diagonalRoundInRadianX = 0.0;
        public double diagonalRoundInRadianY = 0.0;
        public double diagonalRoundInRadianZ = 0.0;
        public double yRoundInRadian = 0.0;
        public Quaternion rotationQuaternion = Quaternion.Identity;

        //physics data
        public Vector3d gravitation = new Vector3d(0, -9.81, 0);
        public Quaterniond gravitationQuaternion = new Quaterniond(0, -9.81, 0, 0);

        public void CalculateInitialRotationQuaternion()
        {
            rotationQuaternion = (new Quaternion(new Vector3((float)alfaAngleInRadian, 0, 0))).Normalized();
        }
    }
}
