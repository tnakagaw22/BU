using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BU.Stock.WebApi;
using BU.Stock.WebApi.Controllers;

namespace BU.Stock.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
