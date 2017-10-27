using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.BLL;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class ViewResultController : Controller
    {
        ViewResultManager viewResultManager = new ViewResultManager();
        // GET: ViewResult
        public ActionResult ViewResult()
        {
            ViewBag.ShowRegNo = viewResultManager.GetRegNos();


            return View();
        }

        public JsonResult GetStudentByRegNos(string RegNo)
        {
            var students = viewResultManager.GetStudentByRegNos(RegNo);
            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }
}