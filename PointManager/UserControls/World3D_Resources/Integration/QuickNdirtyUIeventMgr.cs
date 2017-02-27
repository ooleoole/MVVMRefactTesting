using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace PointManager.UserControls.World3D_Resources.Integration
{
    public class QuickNdirtyUIeventMgr : Border, ISelectedInputInteraction
    {
        public event EventHandler MyPreviewKeyDown;
        public event EventHandler MyPreviewKeyUp;
        public event EventHandler MyPreviewMouseLeftButtonDown;
        public event EventHandler MyPreviewMouseLeftButtonUp;

        public delegate void InteractionEventHandler(string arg);
        public event InteractionEventHandler InteractionEvent;
        public event EventHandler MyPreviewMouseMove;

        public void RaiseInteractionEvent(string arg) { if (InteractionEvent != null) InteractionEvent(arg); }

        private static QuickNdirtyUIeventMgr obj = null;
        private static readonly object lck = new object();
        public static QuickNdirtyUIeventMgr Instance { get { lock (lck) { return obj ?? (obj = new QuickNdirtyUIeventMgr()); } } }
        public QuickNdirtyUIeventMgr()
        {
            if (obj == null) obj = this;
            else if (obj.InteractionEvent != null) { InteractionEvent = obj.InteractionEvent; };
            System.Diagnostics.Debug.WriteLine("QuickNdirtyUIeventMgr() " + GetHashCode());
            Init();
        }

        private void Init()
        {
            this.PreviewKeyDown += xxx_MyPreviewKeyDown;
            this.PreviewKeyUp += xxx_MyPreviewKeyUp;
            //this.MouseWheel += xxx_MyMouseWheel;
            this.PreviewMouseLeftButtonDown += xxx_MyPreviewMouseLeftButtonDown;
            this.PreviewMouseLeftButtonUp += xxx_MyPreviewMouseLeftButtonUp;
            this.PreviewMouseMove += xxx_MyPreviewMouseMove;
        }


        public void xxx_MyPreviewKeyDown(object sender, KeyEventArgs e)
        {
            RaiseInteractionEvent("Keyboard_" + e.Key.ToString().ToUpper() + "_pressed");
        }

        public void xxx_MyPreviewKeyUp(object sender, KeyEventArgs e)
        {
            RaiseInteractionEvent("Keyboard_" + e.Key.ToString().ToUpper() + "_released");
        }

        public void xxx_MyPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RaiseInteractionEvent("Mouse_LEFT_pressed");
        }

        public void xxx_MyPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RaiseInteractionEvent("Mouse_LEFT_released");
        }

        public void xxx_MyPreviewMouseMove(object sender, MouseEventArgs e)
        {
            var p = e.GetPosition(null);
            RaiseInteractionEvent("Cursor_" + p.X + "_" + p.Y);
        }
    }
}