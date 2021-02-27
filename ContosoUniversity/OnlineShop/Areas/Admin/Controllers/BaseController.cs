using OnlineShop.Common;
using OnlineShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting( ActionExecutingContext filterContext )
        {
            var session = GetSessionUser();
            if( session == null )
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            controller = "Login",
                            action = "Index",
                            Area = "Admin"
                        } ) );
            }

            base.OnActionExecuting( filterContext );
        }

        protected User GetSessionUser()
        {
            var session = Session[ CommonConstants.USER_SESSION.ToString() ];
            return session == null ? null : (User)session;
        }
    }
}