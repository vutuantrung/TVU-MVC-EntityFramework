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
using System.Configuration;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class Nationality
    {
        public int ID { get; set; }
        public string Nation { get; set; }
    }

    public class UserController : BaseController
    {
        private readonly UserDAO _userContext = new UserDAO();

        // GET: Admin/User
        public ActionResult Index()
        {
            var webconfigValue = ConfigurationManager.AppSettings[ "testingValueFromWebConfig" ];

            // Get username of the current user
            var userSession = GetSessionUser();

            var model = _userContext.GetAllOthersUser( userSession.UserName );
            return View( model );
        }

        public ActionResult Create()
        {
            SetViewBag();

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

                SetAlert( "User created succesfully.", AlertType.Success );

                return RedirectToAction( "Index", "User" );
            }

            return View();
        }

        public ActionResult Edit( int id )
        {
            var user = _userContext.FindUser( id );

            SetViewBag( user.Nationality );

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

                SetAlert( "User changed succesfully.", AlertType.Success );

                return RedirectToAction( "Index", "User" );
            }

            return View();
        }

        public ActionResult Delete( int id )
        {
            _userContext.DeleteUser( id );

            SetAlert( "User removed succesfully.", AlertType.Success );

            return RedirectToAction( "Index", "User" );
        }

        public ActionResult Details( int id )
        {
            var user = _userContext.FindUser( id );

            return View( user );
        }

        public void SetViewBag( string selectedValue = null )
        {
            List<Nationality> nations = new List<Nationality>();
            nations.Add( new Nationality { Nation = "VietNamese" } );
            nations.Add( new Nationality { Nation = "Japanese" } );
            nations.Add( new Nationality { Nation = "Thailand" } );

            ViewBag.Nationality = new SelectList( nations, "Nation", "Nation", selectedValue );
        }
    }
}