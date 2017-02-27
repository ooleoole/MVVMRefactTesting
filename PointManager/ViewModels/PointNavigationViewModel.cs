using PointManager.Data;
using PointManager.Services;
using System.Collections.ObjectModel;

namespace PointManager.ViewModels
{
    public class PointNavigationViewModel : ViewModelBase
    {
        public PointNavigationViewModel()
        {
            //Repo = new CameraPositionRepository();
            Repo = CameraPositionRepository.Instance;
            ReloadData();
        }

        //public ObservableCollection<CameraPosition> CameraPositions { get; set; }
        private ObservableCollection<CameraPosition> _CameraPositions;
        public ObservableCollection<CameraPosition> CameraPositions {
            get { return _CameraPositions; }
            set { _CameraPositions = value;  OnPropertyChanged("CameraPositions"); } }

        public ICameraPositionRepository Repo { get; set; }

        public void ReloadData()
        {
            CameraPositions = new ObservableCollection<CameraPosition>(Repo.GetCameraPositions());
        }
    }
}