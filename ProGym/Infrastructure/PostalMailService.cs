using ProGym.DAL;
using ProGym.Models;
using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public class PostalMailService : IMailService
    {
        StoreContext db = new StoreContext();
        public void SendOrderConfirmationEmail(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.Name = order.FirstName;
            email.Cost = order.TotalPrice;
            email.OrderNumber = order.OrderID;
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();
           
        }

        public void SendOrderPreparedEmail(Order order)
        {
            
            var order2 = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == order.OrderID && o.LastName == order.LastName);
            OrderPreparedEmail email = new OrderPreparedEmail();
            email.To = order2.Email;
            email.Name = order2.FirstName;
            email.Cost = order2.TotalPrice;
            email.OrderNumber = order2.OrderID;
            email.OrderItems = order2.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();
        }

        public void SendOrderReceivedEmail(Order order)
        {
            OrderReceivedEmail email = new OrderReceivedEmail();
            email.To = order.Email;
            email.Name = order.FirstName;
            email.OrderNumber = order.OrderID;
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();
        }
    }
}