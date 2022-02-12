using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProGym.Controllers;
using ProGym.Infrastructure;
using ProGym.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace ProGym.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Test_StaticContentActionMethod()
        {
            var mailMoq = new Mock<IMailService>();
            var controller = new HomeController(mailMoq.Object);

            var result = controller.StaticContent("test") as ViewResult;

            Assert.AreEqual("test", result.ViewName);
        }

        [TestMethod]
        public void Test_SendContactForm()
        {
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

            var result = (RedirectToRouteResult)controller.SendContactForm(emailModel);

            Assert.AreEqual("StaticContent", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void Test_SendContactMessageEmail()
        {
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

            var result = controller.SendContactMessageEmail(null, emailModel.MessageSubject, emailModel.MessageContent, emailModel.PhoneNumber, emailModel.EmailAddress) as HttpStatusCodeResult;

            Assert.AreEqual(expectedStatus, result.StatusCode);
        }
    }
}
