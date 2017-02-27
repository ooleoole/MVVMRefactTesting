using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Windows;
using System.Windows.Media.Media3D;
//using System.Windows.Input;
using WorkInProgress.MazeFactory;
using WorkInProgress.ViewSupport;


namespace PointManager.UserControls
{
    public partial class World3DView : UserControl
    {
        public World3DView()
        {
            InitializeComponent();
            (new MazeGenerator()).MakeMaze(m3Dg);
        }

/*
        enum MoveMent { Neg = -1, None = 0, Pos = 1 }
        System.Windows.Media.Media3D.PerspectiveCamera newpcam = new PerspectiveCamera();
        System.Windows.Threading.DispatcherTimer timer;
        MoveMent Walk, Strafe;
        double Steps = 1;
        MyCamera CamPos;



        private void PrtCamData()
        {
            TxtX.Text = (Math.Round(CamPos.X, 2)).ToString();
            TxtY.Text = (Math.Round(CamPos.Y, 2)).ToString();
            TxtZ.Text = (Math.Round(CamPos.Z, 2)).ToString();
            txtV.Text = (Math.Round(CamPos.degV, 2)).ToString();
            txtH.Text = (Math.Round(CamPos.degH, 2)).ToString();
        }

        private void Window1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Walk = MoveMent.Pos; break;
                case Key.Down: Walk = MoveMent.Neg; break;
                case Key.Left: Strafe = MoveMent.Neg; break;
                case Key.Right: Strafe = MoveMent.Pos; break;
                case Key.Z: CamPos.Y += 0.1; break;
                case Key.X: CamPos.Y -= 0.1; break;
            }
        }

        private void Window1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Walk = MoveMent.None; break;
                case Key.Down: Walk = Walk = MoveMent.None; break;
                case Key.Left: Strafe = MoveMent.None; break;
                case Key.Right: Strafe = MoveMent.None; break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Walk != MoveMent.None) CamPos.Move((double)Walk * Steps * 0.1);
            if (Strafe != MoveMent.None) CamPos.Strafe((double)Strafe * Steps * 0.1);
            newpcam.Position = CamPos.Position;
            newpcam.LookDirection = new Vector3D(CamPos.Look.X, CamPos.Look.Y, CamPos.Look.Z);
            PrtCamData();
        }

        private void Window1_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Viewport3D1.Camera = newpcam;
            CamPos = new MyCamera() { X = 1, Y = 0.5, Z = 0 }; //CamPos.degH = CamPos.degV =0;
            newpcam.Position = CamPos.Position;
            newpcam.LookDirection = new Vector3D(CamPos.Look.X, CamPos.Look.Y, CamPos.Look.Z);
            (new MazeGenerator()).MakeMaze(m3Dg);
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += new EventHandler(Timer_Tick);
            this.timer.Start();
        }

        private void SetCameraAngles(Point p)
        {
            var midY = this.ActualHeight / 2;
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
            var proc2 = p.X / this.ActualWidth;
            CamPos.degH = 720 - 720 * proc2;
        }

        private void Window1_MouseMove(object sender, MouseEventArgs e) { SetCameraAngles(e.GetPosition(null)); }
*/
    }
}
