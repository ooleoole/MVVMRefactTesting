using PointManager.ViewModels.UNIT;
using System.Windows.Media.Media3D;

namespace PointManager.Models
{
    public class CameraModel : ModelBase, iCameraProperties
    {
        private Point3D _Position;

        public Point3D Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
                OnPropertyChanged("Position");
            } 
            
        }

        private double _degH;

        public double degH { get { return _degH; } set { _degH = AngleInterval(value); OnPropertyChanged("degH"); } }

        private double _degV;
        public double degV { get { return _degV; } set { _degV = AngleInterval(value); OnPropertyChanged("degV");} }
        private double _X;
        public double X { get { return _X; } set { _X = value; OnPropertyChanged("X"); } }

        private double _Y;
        public double Y { get { return _Y; } set { _Y = value; OnPropertyChanged("Y"); } }

        private double _Z;
        public double Z { get { return _Z; } set { _Z = value; OnPropertyChanged("Z"); } }

        private double AngleInterval(double deg)
        {
            if (deg > 360) return deg - 360;
            if (deg < 0) return deg + 360; return deg;

        }
    }
}