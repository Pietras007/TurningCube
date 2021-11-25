using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double diagonalRoundInRadian = 0.0;
        public double yRoundInRadian = 0.0;
    }
}
