using OnlineShop.Areas.Admin.Code;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using OnlineShop.Models;
using OnlineShop.Models.DAO;
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
        readonly UserDAO _userDAO = new UserDAO();

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginMethod( LoginModel model )
        {
            try
            {
                if( !ModelState.IsValid ) throw new Exception( "Login failed! Something went wrong." );

                var user = _userDAO.GetUser( model.UserName, model.Password );

                if( user == null ) throw new Exception( "Login failed! Please check your username or password." );

                // Adding userID and userName into session
                Session.Add( CommonConstants.USER_SESSION.ToString(), user );

                // Using ASP.NET validation
                FormsAuthentication.SetAuthCookie( model.UserName, model.RememberMe );

                return RedirectToAction( "Index", "Home" );
            }
            catch( Exception ex )
            {
                ModelState.AddModelError( "", ex.Message );
                return View( "Index" );
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index( LoginModel model )
        //{
        //    //var result = new AccountModel().Login( model.UserName, model.Password );
        //    if( Membership.ValidateUser( model.UserName, model.Password )
        //        && ModelState.IsValid )
        //    {
        //        // Using custom validation
        //        //var userSession = new UserSession() { UserName = model.UserName };
        //        //SessionHelper.SetSession( userSession );

        //        // Using ASP.NET validation
        //        FormsAuthentication.SetAuthCookie( model.UserName, model.RememberMe );

        //        return RedirectToAction( "Index", "Home" );
        //    }
        //    else
        //    {
        //        ModelState.AddModelError( "", "Invalid username or password" );
        //    }

        //    return View( model );
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction( "Index", "Login" );
        }
    }
}