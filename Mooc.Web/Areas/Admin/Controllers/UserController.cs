using AutoMapper;
using Mooc.Dtos.Base;
using Mooc.Dtos.User;
using Mooc.Services.Interfaces;
using Mooc.Utils;
using Mooc.Web.Areas.Admin.Attribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using System.Web.Security;

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
            //throw new Exception("Index");
            PageResult<UserDto> result = new PageResult<UserDto>() { data = new List<UserDto>(), PageIndex = 0, PageSize = 0 };
            var listview = _userService.GetList();
            result.data = listview;
            result.Count = 0;
            return Json(result);
        }

        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        //Add Create user
        [HttpPost]
        public async Task<JsonResult> Create(CreateOrUpdateUserDto createOrUpdateUserDto)
        {
            CreateOrUpdateUserDto addusr = new CreateOrUpdateUserDto();

            try
            {
                if (!ModelState.IsValid)
                {
                    var c = ModelState;
                    //return Json(new { code = 1, msg = "用户名，性别，角色，专业不能为空" });

                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var key in ModelState.Keys)
                    {
                        var modelstate = ModelState[key];
                        if (modelstate.Errors.Any())
                        {
                            foreach (var item in modelstate.Errors)
                            {
                                stringBuilder.AppendLine(item.ErrorMessage);
                            }
                            //return modelstate.Errors.FirstOrDefault().ErrorMessage;
                            //return Json(new { code = 1,msg= modelstate.Errors.FirstOrDefault().ErrorMessage });
                        }
                    }
                    return Json(new { code = 1,msg= stringBuilder.ToString() });

                }
                else
                {
                    //
                    //Add user to db.
                    //
                    addusr.UserName = createOrUpdateUserDto.UserName;
                    addusr.Gender = createOrUpdateUserDto.Gender;
                    //addusr.RoleType = ;
                    addusr.Major = createOrUpdateUserDto.Major;

                    await this._userService.Add(addusr);

                    return Json(new { code = 0 });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        // Reset Password
        [HttpPost]

        public async Task<JsonResult> Reset(int? id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { code = 1, msg = "用户名Id错误" });
                }
                else
                {
                    var user = await this._userService.GetEditUser(id.Value);

                    if (user != null)
                    {
                        //Generate Random 12 digit password
                        string newpassword = Membership.GeneratePassword(12, 1);
                        string pwd = MD5Help.MD5Encoding(newpassword, ConfigurationManager.AppSettings["sKey"].ToString());
                        user.PassWord = pwd;
                        if (_userService.Update(Mapper.Map<CreateOrUpdateUserDto>(user)))
                        {
                            return Json(new { code = 0, msg = " 密码重置为" + newpassword });
                        }
                        else
                        {
                            return Json(new { code = 1, msg = "密码重置失败，检查数据库连接！" });
                        }
                    }
                    else
                    {
                        return Json(new { code = 1, msg = "不能找到相应用户" });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}