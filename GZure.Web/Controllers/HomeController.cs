using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GZure.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gmail()
        {
            var msg = new MailMessage {From = new MailAddress("dotnetnat@gmail.com")};

            msg.To.Add("podium.2515@gmail.com");
            msg.Subject = "test";
            msg.Body = "Test Content";
            using (var client = new SmtpClient())
            {
                
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("dotnetnat@gmail.com", "s56255625");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                try
                {
                    client.Send(msg);
                    ViewBag.Message = "Success : Test Send Gmail. : podium.2515@gmail.com";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Fail :" + ex.ToString() + " Fail : podium.2515@gmail.com";
                }
                
            }
            return View();
        }
       
    }
}