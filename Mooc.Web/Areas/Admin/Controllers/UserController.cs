using Mooc.Dtos.Base;
using Mooc.Dtos.User;
using Mooc.Services.Interfaces;
using Mooc.Web.Areas.Admin.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooc.Web.Areas.Admin.Controllers
{

    [CheckAdminLogin]
    public class UserController : Controller
    {
        // GET: Admin/User
        
        public ActionResult Index()
        {
            //HttpContext.Session[]
            //var obj = Session["userid"];
            //if (obj == null)
            //{
            //    return RedirectToAction("Index", "Login");

            //}
            //throw new Exception("Index");
            return View();
        }

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult bvg()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserList()
        {
            throw new Exception("Index");
            PageResult<UserDto> result = new PageResult<UserDto>() { data = new List<UserDto>(), PageIndex = 0, PageSize = 0 };
            var listview = _userService.GetList();
            result.data = listview;
            result.Count = 0;
            return Json(result);
        }
    }
}