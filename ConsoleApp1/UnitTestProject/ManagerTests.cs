using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elevator;
using Manager;

namespace UnitTestProject
{
    [TestClass]
    public class ManagerTests
    {
        [TestMethod]
        //[ExpectedException(typeof(Exception))]
        public void TestMethod1()
        {
            Mock<IElevator> mockObject = new Mock<IElevator>();
            mockObject.Setup(m => m.MoveUp(It.IsAny<int>())).Throws(new Exception("Manager Exception"));
            try
            {
                Manager.Manager mngr = new Manager.Manager(mockObject.Object);
                mngr.ButtonPressed(8);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Manager Exception");
            }
        }
    }
}
