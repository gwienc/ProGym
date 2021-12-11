using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProGym.Controllers;
using ProGym.Infrastructure;
using ProGym.ViewModels;

namespace ProGym.Tests
{
    [TestClass]
    public class HomeControllerTests
    {

        [TestMethod]
        public void Test_StaticContentActionMethod()
        {
            //arrange
            var mailMoq = new Mock<IMailService>();
            var controller = new HomeController(mailMoq.Object);

            //act
            var result = controller.StaticContent("test") as ViewResult;

            //assert
            Assert.AreEqual("test", result.ViewName);
        }

        [TestMethod]
        public void Test_SendContactForm()
        {
            //arrange
            var mailMoq = new Mock<IMailService>();
            var controller = new HomeController(mailMoq.Object);

            var emailModel = new ContactMessageEmail()
            {
                Name = "Test",
                PhoneNumber = "394949499",
                EmailAddress = "test@wp.pl",
                MessageContent = "xxx",
                MessageSubject = "zzz",
                To = "xxxx@wp.pl"

            };

            
            //act
            var result = (RedirectToRouteResult)controller.SendContactForm(emailModel);

            //assert
            Assert.AreEqual("StaticContent", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void Test_SendContactMessageEmail()
        {
            //arrange
            var mailMoq = new Mock<IMailService>();
            var expectedStatus = (int)HttpStatusCode.NotFound;
            
            var controller = new HomeController(mailMoq.Object);
            var emailModel = new ContactMessageEmail()
            {
                Name = "Test",
                PhoneNumber = "394949499",
                EmailAddress = "test@wp.pl",
                MessageContent = "xxx",
                MessageSubject = "zzz",
                To = "xxxx@wp.pl"

            };

            //act
            var result = controller.SendContactMessageEmail(null, emailModel.MessageSubject, emailModel.MessageContent, emailModel.PhoneNumber, emailModel.EmailAddress) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(expectedStatus, result.StatusCode);

        }
    }
}
