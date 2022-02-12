using Hangfire;
using ProGym.Models;
using ProGym.ViewModels;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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

        public void SendConfirmationTicketEmailActive(Ticket ticket)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendConfirmationTicketEmailActive", "Manage", new { ticketId = ticket.TicketId, userId = ticket.UserId }, HttpContext.Current.Request.Url.Scheme);

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

        public void TicketInactiveInformationEmail(Ticket ticket)
        {
            var httpContext = HttpContext.Current;

            if (httpContext == null)
            {
                var request = new HttpRequest("/", "http://ProGym.com", "");
                var response = new HttpResponse(new StringWriter());
                httpContext = new HttpContext(request, response);
            }

            var httpContextBase = new HttpContextWrapper(httpContext);
            var routeData = new RouteData();
            var requestContext = new RequestContext(httpContextBase, routeData);
            var urlHelper = new UrlHelper(requestContext);
            string url = urlHelper.Action("TicketInactiveInformationEmail", "Manage", new { ticketId = ticket.TicketId, userId = ticket.UserId });

            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl2(url));
        }

        public void SendContactMessageEmail(ContactMessageEmail email)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendContactMessageEmail", "Home", new { name = email.Name , messageSubject = email.MessageSubject, messageContent = email.MessageContent, phoneNumber = email.PhoneNumber, emailAddress = email.EmailAddress }, HttpContext.Current.Request.Url.Scheme);
                       
            BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
        }
    }
}