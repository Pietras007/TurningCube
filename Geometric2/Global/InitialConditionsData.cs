using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometric2.Global
{
    public class InitialConditionsData
    {
        public double cubeEdgeLength = 1;
        public double cubeDensity = 1;
        public double cubeDeviationRadian = (double)(Math.PI / 180) * 15;
        public double angularVelocityRadian = (double)(Math.PI / 180) * 15;
        public double integrationStep = 0.001;
    }
}
