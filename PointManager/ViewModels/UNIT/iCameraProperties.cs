using System.Windows.Media.Media3D;

namespace PointManager.ViewModels.UNIT
{
    public  interface iCameraProperties
    {
        Point3D Position { get; set; }
        double degH { get; set; }
        double degV { get; set; }

        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}
