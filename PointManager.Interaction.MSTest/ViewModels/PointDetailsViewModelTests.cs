using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  PointManager.Data;
using PointManager.ViewModels.UNIT;


namespace PointManager.ViewModels.Tests
{
    [TestClass()]
    public class PointDetailsViewModelTests
    {
        [TestMethod()]
        public void Cancel_Should_Instantiate_A_New_Instance()
        {
            iPointDetailsViewModel testObject = new PointDetailsViewModel();
            testObject.Instance = null;
            testObject.Cancel();
            Assert.IsTrue(testObject.Instance != null);
        }

        [TestMethod()]
        public void Delete_Should_Not_Operate_On_Nulled_Instance()
        {
            iPointDetailsViewModel testObject = new PointDetailsViewModel();
            testObject.Instance = null;
            bool successfulDeltion = testObject.Delete();
            Assert.AreEqual(successfulDeltion, false);
        }

        [TestMethod()]
        public void Save_Should_Not_Operate_On_Nulled_Instance()
        {
            iPointDetailsViewModel testObject = new PointDetailsViewModel();
            testObject.Instance = null;
            var savedObject = testObject.Save();
            Assert.IsTrue(savedObject == null);
        }
    }
}