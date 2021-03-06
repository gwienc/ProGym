using ProGym.DAL;
using ProGym.Models;
using ProGym.ViewModels;
using System.Linq;

namespace ProGym.Infrastructure
{
    public class PostalMailService : IMailService
    {
        StoreContext db = new StoreContext();
        const string emailAddressProGym = "progym1x1@gmail.com";
        public void SendConfirmationTicketEmail(Ticket ticket)
        {
            var TicketToModify = db.Tickets.Include("TypeOfTicket").SingleOrDefault((t => t.TicketId == ticket.TicketId && t.User.UserData.LastName == ticket.User.UserData.LastName));

            TicketConfirmationEmail email = new TicketConfirmationEmail();
            email.To = ticket.User.UserData.Email;
            email.Name = ticket.User.UserData.FirstName;
            email.TicketName = ticket.TypeOfTicket.TypeTicket.ToString();
            email.ExpirationDate = ticket.ExpirationDate;
            email.PeriodOfValidity = ticket.TypeOfTicket.PeriodOfValidity;
            email.Send();
        }

        public void SendConfirmationTicketEmailActive(Ticket ticket)
        {
            var TicketToModify = db.Tickets.Include("TypeOfTicket").SingleOrDefault((t => t.TicketId == ticket.TicketId && t.User.UserData.LastName == ticket.User.UserData.LastName));

            TicketConfirmationEmail email = new TicketConfirmationEmail();
            email.To = ticket.User.UserData.Email;
            email.Name = ticket.User.UserData.FirstName;
            email.TicketName = ticket.TypeOfTicket.TypeTicket.ToString();
            email.ExpirationDate = ticket.ExpirationDate;
            email.PeriodOfValidity = ticket.TypeOfTicket.PeriodOfValidity;
            email.Send();
        }

        public void TicketInactiveInformationEmail(Ticket ticket)
        {
            var ticketToModify = db.Tickets.Include("TypeOfTicket").SingleOrDefault(t => t.TicketId == ticket.TicketId && t.UserId == ticket.UserId);

            TicketInactiveInformationEmail email = new TicketInactiveInformationEmail();
            email.To = ticket.User.UserData.Email;
            email.Name = ticket.User.UserData.FirstName;
            email.TicketName = ticket.TypeOfTicket.TypeTicket.ToString();
            email.TicketID = ticket.TicketId;
            email.ExpirationDate = ticket.ExpirationDate;
            email.Send();
        }

        public void SendOrderConfirmationEmail(Order order)
        {
            var orderToModify = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == order.OrderID && o.LastName == order.LastName);
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = orderToModify.Email;
            email.Name = orderToModify.FirstName;
            email.Cost = orderToModify.TotalPrice;
            email.OrderNumber = orderToModify.OrderID;
            email.OrderItems = orderToModify.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();          
        }

        public void SendOrderPreparedEmail(Order order)
        {           
            var orderToModify = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == order.OrderID && o.LastName == order.LastName);
            OrderPreparedEmail email = new OrderPreparedEmail();
            email.To = orderToModify.Email;
            email.Name = orderToModify.FirstName;
            email.Cost = orderToModify.TotalPrice;
            email.OrderNumber = orderToModify.OrderID;
            email.OrderItems = orderToModify.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();
        }

        public void SendOrderReceivedEmail(Order order)
        {
            var orderToModify = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == order.OrderID && o.LastName == order.LastName);
            OrderReceivedEmail email = new OrderReceivedEmail();
            email.To = orderToModify.Email;
            email.Name = orderToModify.FirstName;
            email.OrderNumber = orderToModify.OrderID;
            email.OrderItems = orderToModify.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();
        }

        public void SendContactMessageEmail(ContactMessageEmail email)
        {
            ContactMessageEmail contactEmail = new ContactMessageEmail();
            contactEmail.To = emailAddressProGym;
            contactEmail.Name = email.Name;
            contactEmail.MessageSubject = email.MessageSubject;
            contactEmail.MessageContent = email.MessageContent;
            contactEmail.PhoneNumber = email.PhoneNumber;
            contactEmail.EmailAddress = email.EmailAddress;
            contactEmail.Send();
        }
    }
}