using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.BLL;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class UnAssignController : Controller
    {
        UnAssignManager unAssignManager = new UnAssignManager();
        // GET: UnAssign
        public ActionResult UnAssign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssign(int? id)
        {
            ViewBag.Message = unAssignManager.UnAssignAll();
            return View();
        }
    }
}