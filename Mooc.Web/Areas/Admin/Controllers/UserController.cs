using AutoMapper;
using Mooc.Dtos.Base;
using Mooc.Dtos.User;
using Mooc.Services.Interfaces;
using Mooc.Utils;
using Mooc.Web.Areas.Admin.Attribute;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserList(int pageIndex,int pageSize)
        {
            //throw new Exception("Index");
            PageResult<UserDto> result = new PageResult<UserDto>();
            int totalCount=0;
            var listview = _userService.GetListByPage(pageIndex, pageSize,ref totalCount);
            result.PageSize = pageSize;
            result.data = listview;
            result.Count = totalCount;
            return Json(result);

        }

        //Add Create user
         [HttpPost]

         public async Task<JsonResult> Create(CreateOrUpdateUserDto createorUpdateUserDto)
        {
            CreateOrUpdateUserDto addusr = new CreateOrUpdateUserDto();

            try
            {
                if (!ModelState.IsValid)
                {
                    var c = ModelState;

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
                        }
                    }
                    return Json(new { code = 1, msg = stringBuilder.ToString() });
                }
                else
                {
                    addusr.UserName = createorUpdateUserDto.UserName;
                    addusr.Email = createorUpdateUserDto.Email;
                    //addusr.RoleType.GetTypeCode
                    addusr.Gender = createorUpdateUserDto.Gender;
                    addusr.Major = createorUpdateUserDto.Major;

                    var originPW = createorUpdateUserDto.PassWord;
                    
                    string pwd = MD5Help.MD5Encoding(originPW, ConfigurationManager.AppSettings["sKey"].ToString());
                    addusr.PassWord = pwd;

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

        //public async Task<JsonResult> ajCreate(string username, string gender, string role, string major)
        //{
        //    CreateOrUpdateUserDto addusr = new CreateOrUpdateUserDto();

        //    try
        //    {
        //        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(major))
        //        {
        //            return Json(new { code = 1, msg = "用户名，性别，角色，专业不能为空" });
        //        }
        //        else
        //        {
        //            //
        //            //Add user to db.
        //            //
        //            addusr.UserName = username;
        //            addusr.Gender = gender;
        //            //addusr.RoleType = ;
        //            addusr.Major = major;

        //            await this._userService.Add(addusr);

        //            return Json(new { code = 0 });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //       Console.WriteLine(e.Message);
        //       throw;
        //    }
            
        //}

        
        public async Task<JsonResult> DeleteUser(int? DeleteID)
        {
            try
            {
                if (DeleteID == null)
                {
                    return Json(new { code = 1, msg = "用户名ID错误" });
                }
                else
                {
                    var user = await this._userService.GetEditUser(DeleteID.Value);

                    if (user != null && ModelState.IsValid)
                    {
                        this._userService.Delete(DeleteID.Value);
                        return Json(new { code = 0, msg = " 用户" + user.UserName+ "已经删除" });
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

        // Reset Password
        [HttpPost] 
        public async Task<JsonResult> Reset(int? ResetID)
        {
            try
            {
                if (ResetID == null)
                {
                    return Json(new { code = 1, msg = "用户名ID错误" });
                }
                else
                {
                    var user = await this._userService.GetEditUser(ResetID.Value);

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

        //// Edit Password
        //[HttpPost]

        //public async Task<JsonResult> Edit(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return Json(new { code = 1, msg = "用户名ID错误" });
        //        }
        //        else
        //        {
        //            var user = await this._userService.GetEditUser(id.Value);

        //            if (user != null)
        //            {
        //                //Generate Random 12 digit password
        //                string newpassword = Membership.GeneratePassword(12, 1);
        //                string pwd = MD5Help.MD5Encoding(newpassword, ConfigurationManager.AppSettings["sKey"].ToString());
        //                user.PassWord = pwd;
        //                if (_userService.Update(Mapper.Map<CreateOrUpdateUserDto>(user)))
        //                {
        //                    return Json(new { code = 0, msg = " 密码重置为" + newpassword });
        //                }
        //                else
        //                {
        //                    return Json(new { code = 1, msg = "密码重置失败，检查数据库连接！" });
        //                }
        //            }
        //            else
        //            {
        //                return Json(new { code = 1, msg = "不能找到相应用户" });
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}
    }
}