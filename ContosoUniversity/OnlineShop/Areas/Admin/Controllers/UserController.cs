using OnlineShop.Common;
using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserDAO _userContext = new UserDAO();

        // GET: Admin/User
        public ActionResult Index()
        {
            var model = _userContext.GetAllUsers();
            return View( model );
        }

        public ActionResult CreateUserAction( User user )
        {
            if( ModelState.IsValid )
            {
                // Todo:
                // 1. Checking if exist user with same username
                var exsitingUser = _userContext.GetUser( user.UserName );

                // 2. Throw if exist
                if( exsitingUser != null )
                {
                    ModelState.AddModelError( "", "This username is already existed. Please choose another username" );
                    return View();
                }

                // 3. Validation
                user.Password = Encryptor.MD5Hash( user.Password );

                DateTime localDate = DateTime.Now;
                user.CreatedDate = localDate;

                // 4. Insert if not exist
                var lastInsertedID = _userContext.CreateUser( user );
                return RedirectToAction( "Index", "User" );
            }

            return View();
        }
    }
}