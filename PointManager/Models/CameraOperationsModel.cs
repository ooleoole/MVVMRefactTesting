using System;
using System.Windows.Media.Media3D;
using PointManager.ViewModels.UNIT;

namespace PointManager.Models
{
    public class CameraOperationsModel : ModelBase, iCameraInteraction
    {
        private const double halfPi = Math.PI / 180;

        public Vector3D LookDirection(iCameraProperties icp)
        {
            const int dist = 3;
            double X1 = Math.Sin(icp.degH * halfPi) * dist;
            double Z1 = Math.Cos(icp.degH * halfPi) * dist;
            return new Vector3D()
            {
                X = (Math.Cos(icp.degV * halfPi) * X1),
                Y = (Math.Sin(icp.degV * halfPi) * dist),
                Z = (Math.Cos(icp.degV * halfPi) * Z1)
            };
        }

        public void Move(iCameraProperties icp, double Distance)
        {

            icp.X += Math.Sin(icp.degH * halfPi) * Distance;
            icp.Z += Math.Cos(icp.degH * halfPi) * Distance;
        }

        public void Strafe(iCameraProperties icp, double Distance)
        {
            
            var dx = Math.Sin(icp.degH * halfPi) * Distance;
            var dz = Math.Cos(icp.degH * halfPi) * Distance;
            icp.X += -dz;
            icp.Z += dx;
        }
    }
}
