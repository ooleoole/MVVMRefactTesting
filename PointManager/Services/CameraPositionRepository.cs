using System.Collections.Generic;
using PointManager.Data;
using System.Linq;
using System;

namespace PointManager.Services
{
    //class CameraPositionRepository : ICameraPositionRepository

    public sealed class CameraPositionRepository : ICameraPositionRepository
    {
        private static CameraPositionRepository obj = null;
        private static readonly object lck = new object();
        public static CameraPositionRepository Instance { get { lock (lck) { return obj ?? (obj = new CameraPositionRepository()); } } }
        private CameraPositionRepository()
        {
        }
    
        // Förbered för CRUD dataaccess
        Fake_DBContext context = new Fake_DBContext();

        public List<CameraPosition> GetCameraPositions()
        {
            return context.CameraPositions.ToList();
        }

        public CameraPosition GetCameraPosition(int id)
        {
            return context.CameraPositions.FirstOrDefault(c => c.Id == id);
        }

        public CameraPosition AddCameraPosition(CameraPosition cameraPosition)
        {
            context.CameraPositions.Add(cameraPosition);
            return cameraPosition;
        }

        public CameraPosition UpdateCameraPosition(CameraPosition cameraPosition)
        {
            if (context.CameraPositions.Any(c => c.Id == cameraPosition.Id))
            {
                DeleteCameraPosition(cameraPosition);
            }
            AddCameraPosition(cameraPosition);

            return cameraPosition;
        }

        public void DeleteCameraPosition(CameraPosition cameraPosition)
        {
            context.CameraPositions.RemoveAll(c => c.Id == cameraPosition.Id);
        }

    }
}
