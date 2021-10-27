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
    }
}