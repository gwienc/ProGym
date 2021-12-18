using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProGym.App_Start;
using ProGym.Controllers;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.Models;

namespace ProGym.Tests
{
    [TestClass]
    public class ManageControllerTests
    {
        [TestMethod]
        public async Task TestChangePasswordActionMethod_WithModelErrors()
        {
            // Arrange
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new ApplicationUserManager(userStore.Object);
            var mockContext = new Mock<StoreContext>();
            var controller = new ManageController(userManager);
            var vm = new ChangePasswordViewModel();
            controller.ModelState.AddModelError("key", "error");

            // Act
            var result = (RedirectToRouteResult)await controller.ChangePassword(vm);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestChangeOrderStateActionMethod_OrderstateChangesToReceived_SendsConfirmationEmail()
        {
            // Arrange            
            var mockSet = new Mock<DbSet<Order>>();
            Order orderToModify = new Order { OrderID = 1, OrderState = OrderState.InProgress };
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(orderToModify);

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);

            var mailMock = new Mock<IMailService>();

            Order orderArgument = new Order { OrderID = 1, OrderState = OrderState.Received };

            var controller = new ManageController(mailMock.Object,mockContext.Object);

            // Act
            var result = controller.ChangeOrderState(orderArgument);

            // Assert
            mailMock.Verify(m => m.SendOrderReceivedEmail(It.IsAny<Order>()), Times.Once());
        }
    }
}
