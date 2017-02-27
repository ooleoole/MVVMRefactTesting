using System;
using PointManager.Data;

namespace PointManager.ViewModels.UNIT
{
    public interface iPointDetailsViewModel
    {
        CameraPosition Instance { get; set; }
        CameraPosition Save();
        bool Delete();
        void Cancel();
    }
}