using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointManager.ViewModels.UNIT;
// Adda ref 2 "PresentationCore"
using System.Windows.Media.Media3D;
using System;
using System.Security.Policy;
using PointManagerTests.LegacyBehavior;
using PointManagerTests.MovmentSimulator;

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
        public void MoveForwadFullCircleTest_X()
        {
            // Arrange
            var movment = 0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }
        [TestMethod()]
        public void MoveForwadFullCircleTest_Z()
        {
            // Arrange
            var movment = 0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);

        }
        [TestMethod]
        public void MoveBackwardsFullCircleTest_X()
        {
            // Arrange
            var movment = -0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void MoveBackwardsFullCircleTest1_Z()
        {
            // Arrange
            var movment = -0.1;
            var mouseMoveDirectionFlag = true;
            //Act
            do
            {
                mouseMoveDirectionFlag = !mouseMoveDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, mouseMoveDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, mouseMoveDirectionFlag);
                _interaction.Move(_data, movment);
                _confirmedLogic.Move(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);

        }

        [TestMethod()]
        public void StrafeLeftFullCircleTest_Z()
        {
            // Arrange
            var movment = -0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void StrafeRightFullCircleTest_Z()
        {
            // Arrange
            var movment = 0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.Z - _data.Z) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

        [TestMethod()]
        public void StrafeLeftFullCircleTest_X()
        {
            // Arrange
            var movment = -0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }


        [TestMethod()]
        public void StrafeRightFullCircleTest_X()
        {
            // Arrange
            var movment = 0.1;
            var lookDirectionFlag = true;
            //Act
            do
            {
                lookDirectionFlag = !lookDirectionFlag;
                OrientationSimulator.LookDirectionSimulator(_data, lookDirectionFlag);
                OrientationSimulator.LookDirectionSimulator(_confirmedLogic, lookDirectionFlag);
                _interaction.Strafe(_data, movment);
                _confirmedLogic.Strafe(movment);
                // Asssert
                Assert.IsTrue(Math.Abs(_confirmedLogic.X - _data.X) < 0.00001);
            } while (_data.degH < 359.9 && _data.degV < 359.9 && _confirmedLogic.degV < 359.9 && _confirmedLogic.degH < 359.9);
        }

    }
}