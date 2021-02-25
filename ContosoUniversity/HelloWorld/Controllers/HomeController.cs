using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
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

        public ActionResult Profile()
        {
            ViewBag.Message = "Your Profile page.";
            ViewBag.WelcomeString = "Sử dụng ViewBag để pass value to View";

            var message = new MessageModel();
            message.WelcomeMessage = "Sử dụng model để pass value to View";

            return View( message );
        }
    }
}