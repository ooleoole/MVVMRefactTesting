using PointManager.Data;
using PointManager.ViewModels.UNIT;
using PointManager.Services;

namespace PointManager.ViewModels
{
    public class PointDetailsViewModel : ViewModelBase, iPointDetailsViewModel
    {
        public PointDetailsViewModel()
        {
            //Repo = new CameraPositionRepository();
            Repo = CameraPositionRepository.Instance;
        }

        public CameraPosition Instance { get; set; }

        public void Cancel()
        {
            Instance = new CameraPosition();
        }

        public bool Delete()
        {
            if (null == Instance)
                return false;

            Repo.DeleteCameraPosition(Instance);
            Instance = new CameraPosition();


            return true;
        }

        public ICameraPositionRepository Repo { get; set; }
        public CameraPosition Save()
        {
            if (null == Instance)
                return null;

            if (Instance.Id < 1)
                Repo.AddCameraPosition(Instance);
            else
                Repo.UpdateCameraPosition(Instance);

            return Instance;
        }
    }
}