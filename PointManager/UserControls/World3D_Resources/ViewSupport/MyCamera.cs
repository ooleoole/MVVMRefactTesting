//using System;
//using System.Windows.Media.Media3D;
//namespace WorkInProgress.ViewSupport
//{
//    public class MyCamera
//    {
//        public Point3D Position { get { return _Position; } set { _Position = value; } }
//        public double degH { get { return _degH; }
//            set { _degH = AngleInterval(value); } }
//        public double degV { get { return _degV; }
//            set { _degV = AngleInterval(value); } }

//        public double X { get { return _Position.X; } set { _Position.X = value; } }
//        public double Y { get { return _Position.Y; } set { _Position.Y = value; } }
//        public double Z { get { return _Position.Z; } set { _Position.Z = value; } }

//        public Point3D Look
//        {
//            get
//            {
//                const int dist = 3;
//                double X1 = Math.Sin(degH * halfPi) * dist, 
//                       Z1 = Math.Cos(degH * halfPi) * dist;
//                return new Point3D()
//                {
//                    Y = (Math.Sin(degV * halfPi) * dist),
//                    Z = (Math.Cos(degV * halfPi) * Z1),
//                    X = (Math.Cos(degV * halfPi) * X1)
//                };
//            }
//        }

//        public void Move(double Distance)
//        {
//            _Position.X += Math.Sin(degH * halfPi) * Distance;
//            _Position.Z += Math.Cos(degH * halfPi) * Distance; 
            
//        }
//        public void Strafe(double Distance)
//        {
//            var dx = Math.Sin(degH * halfPi) * Distance;
//            var dz = Math.Cos(degH * halfPi) * Distance;
//            _Position.X += -dz;
//            _Position.Z += dx;
//        }
//        private const double halfPi = Math.PI / 180;
//        private Point3D _Position;
//        private double _degH, _degV;

//        private double AngleInterval(double deg)
//        {
//            if (deg > 360) return deg - 360;
//            if (deg < 0) return deg + 360;
//            return deg; 
            
//        }
//    }
//}