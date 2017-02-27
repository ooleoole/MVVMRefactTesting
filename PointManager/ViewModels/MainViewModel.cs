using System;
using PointManager.Data;
using System.Windows.Input;
using PointManager.Commands;
namespace PointManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            System.Diagnostics.Debug.WriteLine("MainViewModel instans skapad: "+DateTime.Now);

            InitUserControlViewModels(); 
            
            InitializeCommands();
        }

        //private CameraPosition _EditCameraPosition;
        //public CameraPosition EditCameraPosition { get { return _EditCameraPosition; } set { _EditCameraPosition = value; OnPropertyChanged("EditCameraPosition");  } }
        public CameraPosition EditCameraPosition { get { return PointDetailsViewModel.Instance; } set { PointDetailsViewModel.Instance = value; OnPropertyChanged("EditCameraPosition"); } }

        private World3DViewModel _World3DViewModel;
        public World3DViewModel World3DViewModel { get { return _World3DViewModel; } set { _World3DViewModel = value; OnPropertyChanged("World3DViewModel"); } }

        private PointNavigationViewModel _PointNavigationViewModel;
        public PointNavigationViewModel PointNavigationViewModel { get { return _PointNavigationViewModel; } set { _PointNavigationViewModel = value; OnPropertyChanged("PointNavigationViewModel"); } }

        private PointDetailsViewModel _PointDetailsViewModel;
        public PointDetailsViewModel PointDetailsViewModel { get { return _PointDetailsViewModel; } set { _PointDetailsViewModel = value; OnPropertyChanged("PointDetailsViewModel"); } }

        private void InitUserControlViewModels()
        {
            World3DViewModel = new World3DViewModel();
            PointNavigationViewModel = new PointNavigationViewModel();
            PointDetailsViewModel = new PointDetailsViewModel();
        }

        private ICommand _SaveCommand;
        public ICommand SaveCommand { get { return _SaveCommand; } set { _SaveCommand = value; OnPropertyChanged("SaveCommand"); } }

        private ICommand _DeleteCommand;
        public ICommand DeleteCommand { get { return _DeleteCommand; } set { _DeleteCommand = value; OnPropertyChanged("DeleteCommand"); } }

        private ICommand _CancelCommand;
        public ICommand CancelCommand { get { return _CancelCommand; } set { _CancelCommand = value; OnPropertyChanged("CancelCommand"); } }


        private void SaveFunction()
        {
            PointDetailsViewModel.Save();
        }

        private void DeleteFunction()
        {
            var success = PointDetailsViewModel.Delete();
            if (success)
                PointNavigationViewModel.ReloadData();
        }

        private void CancelFunction()
        {
        }

        private void InitializeCommands()
        {
            SaveCommand = new SaveCameraPositionCommand(SaveFunction);
            DeleteCommand = new SaveCameraPositionCommand(DeleteFunction);
            CancelCommand = new SaveCameraPositionCommand(CancelFunction);
        }
    }
}