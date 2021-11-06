using Hangfire;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Infrastructure
{
    public class HangFirePostalMailService : IMailService
    {
        public void SendConfirmationTicketEmail(Ticket ticket)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendConfirmationTicketEmail", "Manage", new { ticketId = ticket.TicketId, userId = ticket.UserId }, HttpContext.Current.Request.Url.Scheme);


            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
        }

        public void SendOrderConfirmationEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendConfirmationEmail", "Manage", new { orderid = order.OrderID, lastname = order.LastName }, HttpContext.Current.Request.Url.Scheme);


            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
        }

        public void SendOrderPreparedEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendPreparedOrderEmail", "Manage", new { orderid = order.OrderID, lastname = order.LastName }, HttpContext.Current.Request.Url.Scheme);


            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
        }

        public void SendOrderReceivedEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendReceivedOrderEmail", "Manage", new { orderid = order.OrderID, lastname = order.LastName }, HttpContext.Current.Request.Url.Scheme);


            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
        }
    }
}