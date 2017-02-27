using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointManager.ViewModels.UNIT;
// Adda ref 2 "PresentationCore"
using System.Windows.Media.Media3D;
using System;
using System.Security.Policy;
using PointManagerTests.LegacyBehavior;


namespace PointManager.Models.Tests
{
    public class CameraPropertiesTester : ModelBase, iCameraProperties
    {
        //public CameraPropertiesTester()
        //{
        //    // initiering...
        //}
        public double degH { get; set; }
        public double degV { get; set; }
        public Point3D Position { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

    }
    
    public class CameraOperationsModelTester : ModelBase, iCameraInteraction
    {

        private const double HalfPi = Math.PI / 180;
        public Vector3D LookDirection(iCameraProperties icp)
        {
            throw new NotImplementedException();
        }

        public void Move(iCameraProperties icp, double Distance)
        {
            icp.X += Math.Sin(icp.degH * HalfPi) * Distance;
            icp.Z += Math.Cos(icp.degH * HalfPi) * Distance;
        }

        public void Strafe(iCameraProperties icp, double Distance)
        {
            var dx = Math.Sin(icp.degH * HalfPi) * Distance;
            var dz = Math.Cos(icp.degH * HalfPi) * Distance;
            icp.X += -dz;
            icp.Z += dx;
        }
    }

    [TestClass()]
    public class CameraOperationsModelTests
    {
        private MyCameraLogicKey _confirmedLogic;
        private iCameraProperties _data;
        private iCameraInteraction _interaction;
        [TestInitialize]
        public void Initialize()
        {
            _data = new CameraPropertiesTester()
            {
                X = 1,
                Y = 1,
                Z = 1,
                degH = 0,
                degV = 0
            };
            _interaction = new CameraOperationsModelTester();
            _confirmedLogic = new MyCameraLogicKey { degH = 0, degV = 0, X = 1, Y = 1, Z = 1 };
        }
        
        private void MoveCamera(double steps, bool moveDirectionFlag, iCameraProperties legacyInstance, iCameraProperties newImplementationInstance)
        {
            if (moveDirectionFlag)
            {
                legacyInstance.degH += steps;
                newImplementationInstance.degH += steps;
            }
            else
            {
                legacyInstance.degV += steps;
                newImplementationInstance.degV += steps;
            }
        }

        // TEstar 1,1,1,0,0
        [TestMethod()]
        public void LookDirectionTest_pos()
        {
            // Arrange


            // Act

            var res = _interaction.LookDirection(_data);

            // Assert
            Assert.AreEqual(res.Z, 0);
        }

        [TestMethod()]
        public void MoveForwadInAllDirectionsTest_X()
        {
            // Arrange
            var movment = 0.1;
            var moveDirectionFlag = true;
            //Act
            do
            {
                moveDirectionFlag = !moveDirectionFlag;
                MoveCamera(movment, moveDirectionFlag,_confirmedLogic,_data);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        

        [TestMethod()]
        public void MoveForwadInAllDirectionTest_Z()
        {
            // Arrange
            var movment = 0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);

        }
        [TestMethod]
        public void MoveBackwardsInAllDirectionTest_X()
        {
            // Arrange
            var movment = -0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void MoveBackwardsInAllDirectionTest_Z()
        {
            // Arrange
            var movment = -0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);

        }

        [TestMethod()]
        public void StrafeLeftInAllDirectionTest_Z()
        {
            // Arrange
            var movment = -0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void StrafeRightInAllDirectionTest_Z()
        {
            // Arrange
            var movment = 0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void StrafeLeftInAllDirectionTest_X()
        {
            // Arrange
            var movment = -0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }


        [TestMethod()]
        public void StrafeRightInAllDirectionTest_X()
        {
            // Arrange
            var movment = 0.1;
            var cameraMoveDirectionFlag = true;
            //Act
            do
            {
                cameraMoveDirectionFlag = !cameraMoveDirectionFlag;
                MoveCamera(movment, cameraMoveDirectionFlag, _confirmedLogic, _data);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

    }
}