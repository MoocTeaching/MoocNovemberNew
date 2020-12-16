using Mooc.Services.Interfaces;
using Mooc.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mooc.Web.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService = null;
        public UserLoginController(IUserService userService)
        {
            this._userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> loginPost(string username, string password, bool IsRem)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Json(new { code = 1, msg = "用户名和密码不能为空" });
            }

            var user = await this._userService.GetUser(username);

            if (user != null)
            {
                string pwd = MD5Help.MD5Encoding(password, ConfigurationManager.AppSettings["sKey"].ToString());
                if (user.PassWord == pwd)
                {
                    if (!IsRem)
                    {
                        //CookieHelper.SetCookie("username", user.UserName, DateTime.Now.AddMinutes(7));
                        //CookieHelper.SetCookie("userid", user.Id.ToString(), DateTime.Now.AddDays(7));
                        //Session["userid"] = user;
                    }
                    else
                    {
                        CookieHelper.SetCookie("username", user.UserName, DateTime.Now.AddDays(30));
                        CookieHelper.SetCookie("userid", user.Id.ToString(), DateTime.Now.AddDays(30));
                    }


                    //CookieHelper.SetCookie("username", user.UserName, DateTime.Now.AddDays(7));
                    //CookieHelper.SetCookie("userid", user.Id.ToString(), DateTime.Now.AddDays(7));
                    return Json(new { code = 0 });

                }
                return Json(new { code = 1, msg = "密码错误" });
            }
            return Json(new { code = 1, msg = "错误" });
        }




        public ActionResult DeleteCookie()
        {
            CookieHelper.DeleteCookie("username");
            CookieHelper.DeleteCookie("userid");
            //if (Request.Cookies["username"] != null)
            //{
            //    Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            //}
            return Redirect("~/Login/Index");
        }

    }
}