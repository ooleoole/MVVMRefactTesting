using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointManager.Models;
using PointManager.ViewModels.UNIT;
using PointManagerTests.LegacyBehavior;

namespace PointManagerTests.Models
{
    [TestClass]
    public class CameraModelTest
    {

        private MyCameraLogicKey _confirmedLogic;
        private iCameraProperties _data;

        [TestInitialize]
        public void Initialize()
        {
            _data = new CameraModel()
            {
                X = 1,
                Y = 1,
                Z = 1,
                degH = 0,
                degV = 0
            };
            
            _confirmedLogic = new MyCameraLogicKey { degH = 0, degV = 0, X = 1, Y = 1, Z = 1 };
        }
        [TestMethod]
        public void X_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.X = value;
            _confirmedLogic.X = value;
            //Assert
            Assert.IsTrue(_data.X==_confirmedLogic.X);
        }

        [TestMethod]
        public void Y_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.Y = value;
            _confirmedLogic.Y = value;
            //Assert
            Assert.IsTrue(_data.Y == _confirmedLogic.Y);
        }

        [TestMethod]
        public void Z_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.Z = value;
            _confirmedLogic.Z = value;
            //Assert
            Assert.IsTrue(_data.Z == _confirmedLogic.Z);
        }
        [TestMethod]
        public void DegV_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.degV = value;
            _confirmedLogic.degV = value;
            //Assert
            Assert.IsTrue(_data.degV == _confirmedLogic.degV);
        }

        [TestMethod]
        public void DegH_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.degH = value;
            _confirmedLogic.degH = value;
            //Assert
            Assert.IsTrue(_data.degH == _confirmedLogic.degH);
        }

        [TestMethod]
        public void DegH_DegreesAbove360ResetTest()
        {
            //Arrange
            var value = 365;
            //Act
            _data.degH = value;
            _confirmedLogic.degH = value;
            //Assert
            Assert.IsTrue(_data.degH == _confirmedLogic.degH);
        }

        [TestMethod]
        public void DegV_DegreesAbove360ResetTest()
        {
            //Arrange
            var value = 365;
            //Act
            _data.degV = value;
            _confirmedLogic.degV = value;
            //Assert
            Assert.IsTrue(_data.degV == _confirmedLogic.degV);
        }

        [TestMethod]
        public void DegH_DegreesBelow0ResetTest()
        {
            //Arrange
            var value = -1;
            //Act
            _data.degH = value;
            _confirmedLogic.degH = value;
            //Assert
            Assert.IsTrue(_data.degH == _confirmedLogic.degH);
        }

    }
}
