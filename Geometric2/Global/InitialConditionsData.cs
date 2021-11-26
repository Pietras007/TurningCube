using OpenTK;
using System;

namespace Geometric2.Global
{
    //maybe change it to struct
    public class InitialConditionsData
    {
        public double cubeEdgeLength = 1;
        public double cubeDensity = 1;
        public double cubeDeviationRadian = (double)(Math.PI / 180) * 15;
        public double angularVelocityRadian = (double)(Math.PI / 180) * 15;
        public double integrationStep = 0.001;

        public Vector3d inertiaTensor;
        public double mass;
        public Vector3d massCentre;
        public Quaterniond massCentreQuaternion;

        public void CalculateValues()
        {
            //inertia tensor
            var inertiaTensorBaseX = 11d / 12d;
            var inertiaTensorBaseY = 1d / 6d;
            var inertiaTensorBaseZ = 11d / 12d;

            inertiaTensor = Math.Pow(cubeEdgeLength, 5d) * cubeDensity * new Vector3d(inertiaTensorBaseX, inertiaTensorBaseY, inertiaTensorBaseZ);

            //mass
            mass = Math.Pow(cubeEdgeLength, 3) * cubeDensity;

            //centre of mass
            massCentre = new Vector3d(0, cubeEdgeLength * Math.Sqrt(3) / 2d, 0);
            massCentreQuaternion = new Quaterniond(massCentre, 0f);
        }
    }
}
