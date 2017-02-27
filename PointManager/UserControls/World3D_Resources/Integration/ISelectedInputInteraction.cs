using System;
using System.Windows.Input;

namespace PointManager.UserControls.World3D_Resources.Integration
{
    public interface ISelectedInputInteraction
    {
        event EventHandler MyPreviewKeyDown;
        event EventHandler MyPreviewKeyUp;
        //event EventHandler MyMouseWheel;
        event EventHandler MyPreviewMouseLeftButtonDown;
        event EventHandler MyPreviewMouseLeftButtonUp;

        void xxx_MyPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e);
        void xxx_MyPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e);
        void xxx_MyPreviewKeyDown(object sender, KeyEventArgs e);
        void xxx_MyPreviewKeyUp(object sender, KeyEventArgs e);
        //void xxx_MyMouseWheel(object sender, MouseWheelEventArgs e);

        event EventHandler MyPreviewMouseMove;
        void xxx_MyPreviewMouseMove(object sender, MouseEventArgs e);
    }
}