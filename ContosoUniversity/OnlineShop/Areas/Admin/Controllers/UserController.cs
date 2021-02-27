using OnlineShop.Common;
using OnlineShop.Models.DAO;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OnlineShop.Areas.Admin.Code;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserDAO _userContext = new UserDAO();

        // GET: Admin/User
        public ActionResult Index()
        {
            // Get username of the current user
            var userSession = GetSessionUser();

            var model = _userContext.GetAllOthersUser( userSession.UserName );
            return View( model );
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateUserAction( User user )
        {
            if( ModelState.IsValid )
            {
                // Todo:
                // 1. Checking if exist user with same username
                var exsitingUser = _userContext.FindUser( user.UserName );

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

        public ActionResult Edit( int id )
        {
            var user = _userContext.FindUser( id );

            return View( user );
        }

        [HttpPost]
        public ActionResult EditUserAction( User user )
        {
            if( ModelState.IsValid )
            {
                // Todo:
                // 1. Change modifiedDate and modifiedBy
                DateTime localDate = DateTime.Now;
                user.ModifedDate = localDate;

                user.ModifiedBy = "Admin";

                // 2. Update db
                _userContext.UpdateUser( user );

                return RedirectToAction( "Index", "User" );
            }

            return View();
        }

        public ActionResult Delete( int id )
        {
            _userContext.DeleteUser( id );

            return RedirectToAction( "Index", "User" );
        }

        public ActionResult Details( int id )
        {
            var user = _userContext.FindUser( id );

            return View( user );
        }
    }
}