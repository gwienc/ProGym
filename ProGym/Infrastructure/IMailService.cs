using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Infrastructure
{
    public interface IMailService
    {
        void SendOrderConfirmationEmail(Order order);
        void SendOrderPreparedEmail(Order order);
        void SendOrderReceivedEmail(Order order);
    }
}