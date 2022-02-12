using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProGym.Controllers;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProGym.Tests
{
    [TestClass]
    public class TicketControllerTests
    {
        [TestMethod]
        public void Test_ChooseTicketActionMethod_Count()
        {
            var data = new List<TypeOfTicket>
            {
                new TypeOfTicket {TypeTicket= TypeTicket.OpenMax, Price = 32, PeriodOfValidity = PeriodOfValidity.SixMonth, TypeOfTicketId = 1},
                new TypeOfTicket {TypeTicket = TypeTicket.Open, Price = 52, PeriodOfValidity = PeriodOfValidity.OneMonth, TypeOfTicketId  = 2},
                new TypeOfTicket {TypeTicket = TypeTicket.Student, Price = 65, PeriodOfValidity = PeriodOfValidity.ThreeMonth, TypeOfTicketId = 3},
                new TypeOfTicket {TypeTicket = TypeTicket.Open, Price = 62, PeriodOfValidity = PeriodOfValidity.ThreeMonth, TypeOfTicketId  = 4}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TypeOfTicket>>();
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.TypeOfTickets).Returns(mockSet.Object);
            var mailMock = new Mock<IMailService>();
            var controller = new TicketController(mailMock.Object, mockContext.Object);
            var type = "open";

            var result = controller.ChooseTicket(type) as ViewResult;

            var viewModel = result.ViewData.Model as IEnumerable<TypeOfTicket>;
            Assert.IsTrue(viewModel.Count() == 2);
        }

        [TestMethod]
        public void Test_ChooseTicketActionMethod_TypeOfTicket()
        {
            var data = new List<TypeOfTicket>
            {
                new TypeOfTicket {TypeTicket= TypeTicket.OpenMax, Price = 32, PeriodOfValidity = PeriodOfValidity.SixMonth, TypeOfTicketId = 1},
                new TypeOfTicket {TypeTicket = TypeTicket.Open, Price = 52, PeriodOfValidity = PeriodOfValidity.OneMonth, TypeOfTicketId  = 2},
                new TypeOfTicket {TypeTicket = TypeTicket.Student, Price = 65, PeriodOfValidity = PeriodOfValidity.ThreeMonth, TypeOfTicketId = 3},
                new TypeOfTicket {TypeTicket = TypeTicket.Open, Price = 92, PeriodOfValidity = PeriodOfValidity.SixMonth, TypeOfTicketId  = 4},
                new TypeOfTicket {TypeTicket = TypeTicket.Open, Price = 102, PeriodOfValidity = PeriodOfValidity.ThreeMonth, TypeOfTicketId  = 5}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TypeOfTicket>>();
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TypeOfTicket>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.TypeOfTickets).Returns(mockSet.Object);
            var mailMock = new Mock<IMailService>();
            var controller = new TicketController(mailMock.Object, mockContext.Object);
            var type = "open";

            var result = controller.ChooseTicket(type) as ViewResult;

            var viewModel = (result.ViewData.Model as IEnumerable<TypeOfTicket>).ToArray();
            Assert.AreEqual(type.ToUpper(), viewModel[0].TypeTicket.ToString().ToUpper());
            Assert.AreEqual(type.ToUpper(), viewModel[1].TypeTicket.ToString().ToUpper());
            Assert.AreEqual(type.ToUpper(), viewModel[2].TypeTicket.ToString().ToUpper());
        }

        [TestMethod]
        public void Test_CreateTicketActionMethod()
        {
            var mailMock = new Mock<IMailService>();
            string userId = "1";
            var typeOfTicket = new TypeOfTicket
            {
                TypeTicket = TypeTicket.OpenMax,
                Price = 32,
                PeriodOfValidity = PeriodOfValidity.SixMonth,
                TypeOfTicketId = 1
            };
            var ticket = new Ticket()
            {
                UserId = userId,
                IsActive = true,
                DateOfPurchase = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(2),
                TypeOfTicketId = typeOfTicket.TypeOfTicketId

            };
            var expectedTicket = new Ticket()
            {
                UserId = userId,
                IsActive = false,
                DateOfPurchase = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(2),
                TypeOfTicketId = typeOfTicket.TypeOfTicketId

            };
            var ticketMock = new Mock<DbSet<Ticket>>();
            ticketMock.Setup(m => m.Find(It.IsAny<int>())).Returns(ticket);
            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Tickets).Returns(ticketMock.Object);
            var controller = new TicketController(mailMock.Object, mockContext.Object);

            var result = controller.CreateTicket(userId, ticket);

            Assert.AreEqual(expectedTicket.IsActive, result.IsActive);
            Assert.AreEqual(expectedTicket.DateOfPurchase, result.DateOfPurchase);
            Assert.AreEqual(expectedTicket.ExpirationDate, result.ExpirationDate);
            Assert.AreEqual(expectedTicket.TypeOfTicketId, result.TypeOfTicketId);
            Assert.AreEqual(expectedTicket.UserId, result.UserId);
        }

        [TestMethod]
        public void Test_UpdateTicketActionMethod()
        {
            var mailMock = new Mock<IMailService>();
            string userId = "2";
            var typeOfTicket = new TypeOfTicket
            {
                TypeTicket = TypeTicket.OpenMax,
                Price = 32,
                PeriodOfValidity = PeriodOfValidity.SixMonth,
                TypeOfTicketId = 1
            };
            var tickets = new List<Ticket>
            {
                new Ticket {UserId = userId, IsActive = true, DateOfPurchase = DateTime.Now, ExpirationDate = DateTime.Now.AddHours(2), TypeOfTicketId = typeOfTicket.TypeOfTicketId}
            }.AsQueryable();
            var expectedTicket = new Ticket()
            {
                UserId = userId,
                IsActive = true,
                DateOfPurchase = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(2),
                TypeOfTicketId = typeOfTicket.TypeOfTicketId

            };
            var newTicket = new Ticket()
            {
                UserId = userId,
                IsActive = false,
                DateOfPurchase = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(2),
                TypeOfTicketId = typeOfTicket.TypeOfTicketId

            };
            var ticketMock = new Mock<DbSet<Ticket>>();
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(tickets.Provider);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(tickets.Expression);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(tickets.ElementType);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(tickets.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Tickets).Returns(ticketMock.Object);
            var controller = new TicketController(mailMock.Object, mockContext.Object);

            var result = controller.UpdateTicket(userId, newTicket);

            Assert.AreEqual(expectedTicket.IsActive, result.IsActive);
            Assert.AreEqual(expectedTicket.DateOfPurchase, result.DateOfPurchase);
            Assert.AreEqual(expectedTicket.ExpirationDate, result.ExpirationDate);
            Assert.AreEqual(expectedTicket.TypeOfTicketId, result.TypeOfTicketId);
            Assert.AreEqual(expectedTicket.UserId, result.UserId);
        }

        [TestMethod]
        public async Task Test_BuyTicketActionMethod()
        {
            var mailMock = new Mock<IMailService>();
            string userId = "2";
            var typeOfTicket = new TypeOfTicket
            {
                TypeTicket = TypeTicket.OpenMax,
                Price = 32,
                PeriodOfValidity = PeriodOfValidity.SixMonth,
                TypeOfTicketId = 1
            };
            var tickets = new List<Ticket>
            {
                new Ticket {UserId = userId, IsActive = true, DateOfPurchase = DateTime.Now, ExpirationDate = DateTime.Now.AddHours(2), TypeOfTicketId = typeOfTicket.TypeOfTicketId}
            }.AsQueryable();
            var newTicket = new Ticket()
            {
                UserId = userId,
                IsActive = false,
                DateOfPurchase = DateTime.Now,
                ExpirationDate = DateTime.Now.AddHours(2),
                TypeOfTicketId = typeOfTicket.TypeOfTicketId

            };
            var ticketMock = new Mock<DbSet<Ticket>>();
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.Provider).Returns(tickets.Provider);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.Expression).Returns(tickets.Expression);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.ElementType).Returns(tickets.ElementType);
            ticketMock.As<IQueryable<Ticket>>().Setup(m => m.GetEnumerator()).Returns(tickets.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Tickets).Returns(ticketMock.Object);
            var controller = new TicketController(mailMock.Object, mockContext.Object);
            controller.ModelState.AddModelError("key", "error");

            var ticket = (ViewResult)await controller.BuyTicket(newTicket);
            var result = ticket.ViewData.Model as Ticket;

            Assert.AreEqual(1, result.TypeOfTicketId);
            Assert.AreEqual("2", result.UserId);
            Assert.AreEqual(false, result.IsActive);
        }
    }
}
