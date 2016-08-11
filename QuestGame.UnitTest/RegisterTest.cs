using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuestGame.WebApi.Controllers;
using System.Web.Mvc;

namespace QuestGame.UnitTest
{
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void IsViewReturn()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
