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
    public class TeachersController : Controller
    {
        private ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            this._teacherService = teacherService;
        }

        public ActionResult Index()
        {
            var list = _teacherService.GetList();
            return View(list);
        }


    }
}