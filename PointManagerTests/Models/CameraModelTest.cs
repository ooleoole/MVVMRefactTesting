using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointManager.Models;
using PointManager.Models.Tests;
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

        public void X_PropTest()
        {
            //Arrange
            var value = 5;
            //Act
            _data.X = value;
            _confirmedLogic.X = value;
            //
        }
    }
}
