using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric2.Global
{
    public class GlobalPhysicsData
    {
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
        public float alfaAngleInRadian = 0.5f;
        public float diagonalRoundInRadian = 0.0f;
        public float yRoundInRadian = 0.0f;
    }
}
