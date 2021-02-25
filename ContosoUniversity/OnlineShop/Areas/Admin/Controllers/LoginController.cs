using OnlineShop.Areas.Admin.Code;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index( LoginModel model )
        {
            //var result = new AccountModel().Login( model.UserName, model.Password );
            if( Membership.ValidateUser( model.UserName, model.Password ) 
                && ModelState.IsValid )
            {
                // Using custom validation
                //var userSession = new UserSession() { UserName = model.UserName };
                //SessionHelper.SetSession( userSession );

                // Using ASP.NET validation
                FormsAuthentication.SetAuthCookie( model.UserName, model.RememberMe );

                return RedirectToAction( "Index", "Home" );
            }
            else
            {
                ModelState.AddModelError( "", "Invalid username or password" );
            }

            return View( model );
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction( "Index", "Login" );
        }
    }
}