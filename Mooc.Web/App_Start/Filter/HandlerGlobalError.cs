using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Mooc.Web.App_Start.Filter
{
    public class HandlerGlobalError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //filterContext.Result = new ViewContext();
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var obj = new AjaxResutn();
                obj.code = 0;
                obj.msg = "ffff";
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.Result = new ContentResult() { Content = JsonConvert.SerializeObject(obj), ContentEncoding = Encoding.UTF8, ContentType = "application/json" };
            }
            else {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.HttpContext.Response.Redirect("~/Home/Error");
            }
            
        }
    }

    public class AjaxResutn
    {
        public string msg { get; set; }

        public int code { get; set; }

    }
}