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

        public ActionResult LoginAction( LoginModel model )
        {
            try
            {
                if( !ModelState.IsValid ) throw new Exception( "Login failed! Something went wrong." );

                var user = _userDAO.FindUser
                ( 
                    model.UserName,
                    Encryptor.MD5Hash( model.Password )
                );

                if( user == null ) throw new Exception( "Login failed! Please check your username or password." );

                // Adding userID and userName into session
                Session.Add( CommonConstants.USER_SESSION.ToString(), user );

                // Using ASP.NET validation
                // FormsAuthentication.SetAuthCookie( model.UserName, model.RememberMe );

                return RedirectToAction( "Index", "Home" );
            }
            catch( Exception ex )
            {
                ModelState.AddModelError( "", ex.Message );
                return View( "Index" );
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction( "Index", "Login" );
        }
    }
}