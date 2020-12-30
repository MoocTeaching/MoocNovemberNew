using Mooc.Dtos.User;
using Mooc.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mooc.Web.Controllers
{
    public class UsersController : Controller
    {
        //private DataContext db = new DataContext();
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: Users
        public ActionResult Index()
        {
            //throw new System.Exception("Error");

            var list = _userService.GetList();

            return View(list);
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = await this._userService.GetUser(id.Value);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            }
            //var list = _userService.GetList();

            //UserDto user = list.Find(a => a.Id == id);
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,UserName,PassWord,Email,UserState,RoleType,AddTime")] CreateOrUpdateUserDto user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this._userService.Add(user);
        //    }

        //    return View(user);
        //}

        [HttpPost]
        public async Task<JsonResult> createPost(string username, string gender, string role, string major)
        {
            CreateOrUpdateUserDto addusr = new CreateOrUpdateUserDto();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(major))
            {
                return Json(new { code = 1, msg = "用户名，性别，角色，专业不能为空" });
            }
            else
            {
                //
                //Add user to db.
                //
                addusr.UserName = username;
                addusr.Gender = gender;
                //addusr.RoleType = ;
                addusr.Major = major;

                await this._userService.Add(addusr);

                return Json(new { code = 0 });
            }
        }
        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //User user = await db.Users.FindAsync(id);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(user);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await this._userService.GetEditUser(id.Value);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            }
            //var list = _userService.GetList();

            //UserDto user = list.Find(a => a.Id == id);
            return View(user);
        }

        // POST: Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,PassWord,Email,UserState,RoleType,AddTime")] CreateOrUpdateUserDto user)
        {
            if (ModelState.IsValid)
            {
                this._userService.Update(user);
            }

            return View(user);

        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //User user = await db.Users.FindAsync(id);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(user);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await this._userService.GetEditUser(id.Value);

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await this._userService.GetEditUser(id);

            if (ModelState.IsValid)
            {
                this._userService.Delete(id);
            }

            return RedirectToAction("Index");
        }
    }
}