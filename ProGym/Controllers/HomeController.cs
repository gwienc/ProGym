using Hangfire;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class HomeController : Controller
    {
       
        const string emailAddressProGym = "progym1x1@gmail.com";
        
        private IMailService mailService;
              
        
        public HomeController(IMailService mailService)
        {
            this.mailService = mailService;
        }    
        
       
        
        
        public ActionResult Index()
        { 
            return View();
        }

        [OutputCache(Duration =86400)]
        public ActionResult StaticContent(string viewname, bool sendMessage = false)
        {
            if (sendMessage == true)
            {
                ViewBag.ConfirmMessage = "Wiadomość została wysłana!";
            }
            
            return View(viewname);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendContactForm(ContactMessageEmail email)
        {          
            this.mailService.SendContactMessageEmail(email);
              
            return RedirectToAction("StaticContent", new { viewname = "Contact", sendMessage = true });
        }
 
        public ActionResult SendContactMessageEmail(string name, string messageSubject, string messageContent, string phoneNumber, string emailAddress)
        {
            
            if (name == null || messageSubject == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            
            ContactMessageEmail contactEmail = new ContactMessageEmail();
            contactEmail.To = emailAddressProGym;
            contactEmail.Name = name;
            contactEmail.MessageSubject = messageSubject;
            contactEmail.MessageContent = messageContent;
            contactEmail.PhoneNumber = phoneNumber;
            contactEmail.EmailAddress = emailAddress;
            contactEmail.Send();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);

        }
    }
}