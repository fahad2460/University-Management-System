using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        // GET: EnrollCourse
        public ActionResult EnrollCourse()
        {
            ViewBag.ShowRegNo = enrollCourseManager.GetRegNos();
            return View();
        }
        public JsonResult GetStudentByRegNos(string RegNo)
        {
            var students = enrollCourseManager.GetStudentByRegNos(RegNo);
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {
            ViewBag.ShowRegNo = enrollCourseManager.GetRegNos();
            ViewBag.Message = enrollCourseManager.EnrollInCourse(enrollCourse);
            return View();
        }
    }
}