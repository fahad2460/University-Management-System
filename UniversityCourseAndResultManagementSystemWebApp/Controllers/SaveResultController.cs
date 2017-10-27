using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class SaveResultController : Controller
    {
        SaveResultManager saveResultManager=new SaveResultManager();
        // GET: SaveResult
        public ActionResult SaveResult()
        {
            ViewBag.ShowGrade = saveResultManager.GetGrades();
            ViewBag.ShowRegNo = saveResultManager.GetRegNos();

            return View();
        }
          [HttpPost]
        public JsonResult GetStudentByRegNos(string RegNo)
        {
            var students = saveResultManager.GetStudentByRegNos(RegNo);
            return Json(students, JsonRequestBehavior.AllowGet);
        }

          [HttpPost]
      
        public ActionResult SaveResult(StudentModel studentInformation)
        {
            ViewBag.ShowGrade = saveResultManager.GetGrades();
            ViewBag.ShowRegNo = saveResultManager.GetRegNos();
            ViewBag.Message = saveResultManager.SaveResult(studentInformation);
            return View();
        }
    }
}