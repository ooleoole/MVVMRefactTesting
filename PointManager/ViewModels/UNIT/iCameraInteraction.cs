using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace PointManager.ViewModels.UNIT
{
    public interface iCameraInteraction
    {
        Vector3D LookDirection(iCameraProperties icp);
        void Move(iCameraProperties icp, double Distance);
        void Strafe(iCameraProperties icp, double Distance);
    }
}
