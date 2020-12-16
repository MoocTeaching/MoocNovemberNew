using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mooc.Services.Interfaces;
using Mooc.Web;
using Mooc.Web.Controllers;

namespace Mooc.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            IUserService userService = UTestConfigHelper.ResolveServcie<IUserService>();
          //  HomeController controller = new HomeController(userService);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            //// Arrange
            //IUserService userService = new UserService();
            //HomeController controller = new HomeController(userService);

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //IUserService userService = new UserService();
            //HomeController controller = new HomeController(userService);

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}

