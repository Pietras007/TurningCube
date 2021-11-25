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
        public decimal alfaAngleInRadian = 0.5M;
        public decimal diagonalRoundInRadian = 0.0M;
        public decimal yRoundInRadian = 0.0M;
    }
}
