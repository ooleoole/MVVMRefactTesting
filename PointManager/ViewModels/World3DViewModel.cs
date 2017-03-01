using System;
using PointManager.UserControls.World3D_Resources.Integration;
using WorkInProgress.ViewSupport;
using System.Windows.Media.Media3D;
using System.Windows;

namespace PointManager.ViewModels
{
    public class World3DViewModel : ViewModelBase
    {
        public World3DViewModel()
        {
            System.Diagnostics.Debug.WriteLine("Ctor  World3DViewModel" + DateTime.Now);
            QuickNdirtyUIeventMgr.Instance.InteractionEvent += InteractionEventFunction;
            InitCamera();
        }

        private string _Info;
        public string Info { get { return _Info; } set { { _Info = value; OnPropertyChanged("Info"); } } }

        void InteractionEventFunction(string evt)
        {
            Info = evt;
            StringToAction(evt);
        }

        enum MoveMent { Neg = -1, None = 0, Pos = 1 }
        MoveMent Walk, Strafe;
        double Steps = 1;

        private MyCamera _CamPos;
        public MyCamera CamPos { get { return _CamPos; } set { _CamPos = value; OnPropertyChanged("CamPos"); } }

        private PerspectiveCamera _MyPerspectiveCamera;
        public PerspectiveCamera MyPerspectiveCamera { get { return _MyPerspectiveCamera; } set { _MyPerspectiveCamera = value; OnPropertyChanged("MyPerspectiveCamera"); } }

        private void InitCamera()
        {
            MyPerspectiveCamera = new PerspectiveCamera();
            CamPos = new MyCamera() { X = 1, Y = 0.5, Z = 0, degH = 0, degV = 0 };
            MyPerspectiveCamera.Position = CamPos.Position;
            MyPerspectiveCamera.LookDirection = new Vector3D(CamPos.Look.X, CamPos.Look.Y, CamPos.Look.Z);
        }

        private void StringToAction(string str)
        {
            str = str.ToLower();

            if (str.Contains("keyboard"))
            {
                if (str.Contains("up")) Walk = MoveMent.Pos;
                if (str.Contains("down")) Walk = MoveMent.Neg;

                if (str.Contains("left")) Strafe = MoveMent.Neg;
                if (str.Contains("right")) Strafe = MoveMent.Pos;

                if (str.Contains("z")) CamPos.Y += 0.1;
                if (str.Contains("x")) CamPos.Y -= 0.1;
            }

            if (str.Contains("cursor"))
            {
                string[] koord = str.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                double x;
                double.TryParse(koord[1], out x);
                double y;
                double.TryParse(koord[2], out y);
                SetCameraAngles(new Point(x, y));
            }


            if (Walk != MoveMent.None)
            {
                CamPos.Move((double)Walk * Steps * 0.1);
                Walk = MoveMent.None;
            }

            if (Strafe != MoveMent.None)
            {
                CamPos.Strafe((double)Strafe * Steps * 0.1);
                Strafe = MoveMent.None;
            }

            MyPerspectiveCamera.Position = CamPos.Position;
            MyPerspectiveCamera.LookDirection = new Vector3D(CamPos.Look.X, CamPos.Look.Y, CamPos.Look.Z);
            // Nödlösning för att få de interna propparna att uppdatera
            OnPropertyChanged("CamPos");
        }

        private void SetCameraAngles(Point p)
        {
            //var midY = this.ActualHeight / 2;
            var midY = SystemParameters.PrimaryScreenHeight / 2;
            // ned:  360-270.
            if (p.Y > midY)
            {
                var proc = (p.Y - midY) / midY;
                CamPos.degV = 360 - 90 * proc;
            }
            // Vert: up:  0-90
            if (p.Y < midY)
            {
                var proc = p.Y / midY;
                CamPos.degV = 90 - 90 * proc;
            }
            //var proc2 = p.X / this.ActualWidth;
            var proc2 = p.X / SystemParameters.PrimaryScreenWidth;
            CamPos.degH = 720 - 720 * proc2;
        }
    }
}