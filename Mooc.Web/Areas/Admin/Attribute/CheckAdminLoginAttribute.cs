using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mooc.Web.Areas.Admin.Attribute
{
    public class CheckAdminLoginAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Session["userid"] == null)
            {
                if (filterContext.HttpContext.Request.Cookies["userid"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                {
                    {"controller","Login" },
                    {"action","Index" }
                });
                }
            }
        }
    }
}