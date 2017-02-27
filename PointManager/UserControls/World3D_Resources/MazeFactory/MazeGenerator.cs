using System;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Collections.Generic;
using WorkInProgress.Utility;

namespace WorkInProgress.MazeFactory
{
    public class MazeGenerator
    {
        double Base = 0, Top = 1.5, dv = 0.04;

        public void MakeMaze(Model3DGroup m3Dg)
        {
            var path = Environment.CurrentDirectory+ @"\UserControls\World3D_Resources\Images";
            ImageBrush Base_bmp = new ImageBrush() { ImageSource = new BitmapImage(new Uri(Path.Combine(path, "Base.jpg"))) };
            Base_bmp.Opacity = 0.5;
            ImageBrush Top_bmp = new ImageBrush() { ImageSource = new BitmapImage(new Uri(Path.Combine(path, "Top.jpg"))) };
            ImageBrush Inner_bmp = new ImageBrush() { ImageSource = new BitmapImage(new Uri(Path.Combine(path, "Inner.jpg"))) };
            Inner_bmp.Opacity = 0.65;
            ImageBrush Outer_bmp = new ImageBrush() { ImageSource = new BitmapImage(new Uri(Path.Combine(path, "Outer.jpg"))) };
            //Outer_bmp.Opacity = 0.1;

            Material Base_Material = new DiffuseMaterial(Base_bmp);
            Material Top_Material = new DiffuseMaterial(Top_bmp);
            Material Outer_Material = new DiffuseMaterial(Outer_bmp);
            Material Inner_Material = new DiffuseMaterial(Inner_bmp);

            MeshGeometry3D Base_mg3 = CreateMg3(m3Dg, Base_Material);
            MeshGeometry3D Top_mg3 = CreateMg3(m3Dg, Top_Material);
            MeshGeometry3D Outer_mg3 = CreateMg3(m3Dg, Outer_Material);
            MeshGeometry3D Inner_mg3 = CreateMg3(m3Dg, Inner_Material);

            int minX = -15, minZ = -15;
            // Base
            for (int x = minX; x <= 3; x += 2)
                for (int z = minZ; z <= 3; z += 2)
                    Triangulate(Base_mg3, new Point3D(x, Base, z), new Point3D(x, Base, z + 2), new Point3D(x + 2, Base, z + 2), new Point3D(x + 2, Base, z), new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));

            // Top.
            for (int x = minX; x <= 4; x += 1)
                for (int z = minZ; z <= 4; z += 1)
                    Triangulate(Top_mg3, new Point3D(x, Top, z), new Point3D(x + 1, Top, z), new Point3D(x + 1, Top, z + 1), new Point3D(x, Top, z + 1), new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));

            //var sky = Top;
            //sky = 20;
            //// Top.
            //for (int x = -150; x <= 150; x++)
            //    for (int z = -150; z <= 150; z++)
            //        Triangulate(Top_mg3, new Point3D(x, sky, z), new Point3D(x + 1, sky, z), new Point3D(x + 1, sky, z + 1), new Point3D(x, sky, z + 1), new Point(0, 0), new Point(0, 1), new Point(1, 1), new Point(1, 0));



            // Outer pair 1:2
            for (int x = minX; x <= 3; x += 2)
            {
                Triangulate(Outer_mg3, new Point3D(x, Top, -5), new Point3D(x, Base, -5), new Point3D(x + 2, Base, -5), new Point3D(x + 2, Top, -5), new Point(0, 0), new Point(0, 1), new Point(0.5, 1), new Point(0.5, 0));
                Triangulate(Outer_mg3, new Point3D(x + 2, Top, 5), new Point3D(x + 2, Base, 5), new Point3D(x, Base, 5), new Point3D(x, Top, 5), new Point(0, 0), new Point(0, 1), new Point(0.5, 1), new Point(0.5, 0));
            }

            // Outer pair 2:2
            for (int z = -5; z <= 3; z += 2)
            {
                Triangulate(Outer_mg3, new Point3D(5, Top, z), new Point3D(5, Base, z), new Point3D(5, Base, z + 2), new Point3D(5, Top, z + 2), new Point(0, 0), new Point(0, 1), new Point(0.5, 1), new Point(0.5, 0));
                Triangulate(Outer_mg3, new Point3D(-5, Top, z + 2), new Point3D(-5, Base, z + 2), new Point3D(-5, Base, z), new Point3D(-5, Top, z), new Point(0, 0), new Point(0, 1), new Point(0.5, 1), new Point(0.5, 0));
            }

            List<int> K = new List<int>() { -1, -5, -1, -4, -2, -4, -2, -3, -1, -4, -1, -3, 4, -4, 4, -3, -2, -3, -2, -2, 3, -3, 3, -2, 4, -3, 4, -2, -3, -2, -3, -1, 1, -2, 1, -1, 2, -2, 2, -1, 3, -2, 3, -1, 4, -2, 4, -1, -3, -1, -3, 0, -2, -1, -2, 0, -1, -1, -1, 0, 0, -1, 0, 0, 1, -1, 1, 0, 2, -1, 2, 0, 4, -1, 4, 0, -4, 0, -4, 1, -3, 0, -3, 1, -2, 0, -2, 1, 0, 0, 0, 1, 1, 0, 1, 1, 2, 0, 2, 1, 3, 0, 3, 1, 4, 0, 4, 1, -4, 1, -4, 2, -3, 1, -3, 2, -2, 1, -2, 2, -1, 1, -1, 2, 1, 1, 1, 2, 2, 1, 2, 2, 3, 1, 3, 2, -4, 2, -4, 3, -3, 2, -3, 3, -2, 2, -2, 3, 2, 2, 2, 3, 4, 2, 4, 3, -4, 3, -4, 4, -2, 3, -2, 4, -1, 3, -1, 4, 3, 3, 3, 4, 4, 3, 4, 4, -1, 4, -1, 5, 4, 4, 4, 5, -5, -3, -4, -3, -5, -1, -4, -1, -4, -4, -3, -4, -4, -3, -3, -3, -4, -2, -3, -2, -4, 4, -3, 4, -3, -4, -2, -4, -3, -2, -2, -2, -3, 4, -2, 4, -2, -2, -1, -2, -2, 2, -1, 2, -1, -3, -0, -3, -1, -2, -0, -2, -1, -1, -0, -1, -1, 1, -0, 1, -1, 3, -0, 3, 0, -4, 1, -4, 0, -3, 1, -3, 0, -2, 1, -2, 0, 2, 1, 2, 0, 3, 1, 3, 0, 4, 1, 4, 1, -4, 2, -4, 1, -3, 2, -3, 1, 4, 2, 4, 2, -4, 3, -4, 2, -3, 3, -3, 2, 3, 3, 3, 2, 4, 3, 4, 3, -4, 4, -4, 3, 2, 4, 2 };
            for (int i = 0; i + 4 < K.Count; i += 4)
                ExtrudeSurface(ref Inner_mg3, new Surface() { X1 = K[i], Z1 = K[i + 1], X2 = K[i + 2], Z2 = K[i + 3] });
        }

        private MeshGeometry3D CreateMg3(Model3DGroup Model, Material Image)
        {
            var tmp = new MeshGeometry3D();
            var new_model = new GeometryModel3D(tmp, Image);
            Model.Children.Add(new_model);
            return tmp;
        }

        private void Triangulate(MeshGeometry3D mg3, Point3D A, Point3D B, Point3D C, Point3D D, Point M, Point N, Point O, Point P)
        {
            // Set points.
            mg3.Positions.Add(A);
            mg3.Positions.Add(B);
            mg3.Positions.Add(C);
            mg3.Positions.Add(D);

            // Set texture coords.
            mg3.TextureCoordinates.Add(M);
            mg3.TextureCoordinates.Add(N);
            mg3.TextureCoordinates.Add(O);
            mg3.TextureCoordinates.Add(P);

            // Define two triangles for each rectangle.
            var TPoint = mg3.Positions.Count - 4;
            mg3.TriangleIndices.Add(TPoint);
            mg3.TriangleIndices.Add(TPoint + 1);
            mg3.TriangleIndices.Add(TPoint + 2);
            mg3.TriangleIndices.Add(TPoint);
            mg3.TriangleIndices.Add(TPoint + 2);
            mg3.TriangleIndices.Add(TPoint + 3);
        }

        private void ExtrudeSurface(ref MeshGeometry3D mg3, Surface wall)
        {
            double xStep = 0;
            double zStep = 0;
            var Direction = false;
            double xMin = Math.Min(wall.X1, wall.X2);
            double xMax = Math.Max(wall.X1, wall.X2);
            double zMin = Math.Min(wall.Z1, wall.Z2);
            double zMax = Math.Max(wall.Z1, wall.Z2);

            if (xMin == xMax)
            {
                xStep = dv / 2;
                Direction = true;
            }

            if (zMin == zMax)
            {
                zStep = dv / 2;
                Direction = false;
            }

            var A = new Point3D(xMin - xStep, Top, zMin - zStep);
            var B = new Point3D(xMin - xStep, Top, zMax + zStep);
            var C = new Point3D(xMax + xStep, Top, zMax + zStep);
            var D = new Point3D(xMax + xStep, Top, zMin - zStep);
            var E = A;
            var F = B;
            var G = C;
            var H = D;
            E.Y = Base;
            F.Y = Base;
            G.Y = Base;
            H.Y = Base;

            var M = new Point(0, 0);
            var N = new Point(0, 1);
            var O = new Point(1, 1);
            var P = new Point(1, 0);

            CreateSolid(mg3, A, B, C, D, E, F, G, H, M, N, O, P, Direction);
        }

        private void CreateSolid(MeshGeometry3D mg3, Point3D A, Point3D B, Point3D C, Point3D D, Point3D E, Point3D F, Point3D G, Point3D H, Point M, Point N, Point O, Point P, bool direction)
        {
            if (direction)
            {
                Triangulate(mg3, B, C, D, A, M, N, O, P);
                Triangulate(mg3, G, F, E, H, M, N, O, P);
            }
            else
            {
                Triangulate(mg3, A, B, C, D, M, N, O, P);
                Triangulate(mg3, H, G, F, E, M, N, O, P);
            }
            Triangulate(mg3, A, E, F, B, M, N, O, P);
            Triangulate(mg3, C, G, H, D, M, N, O, P);

            Triangulate(mg3, B, F, G, C, M, N, O, P);
            Triangulate(mg3, D, H, E, A, M, N, O, P);
        }
    }
}