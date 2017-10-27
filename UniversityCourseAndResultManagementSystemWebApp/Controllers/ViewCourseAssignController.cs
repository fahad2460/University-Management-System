using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.DAL;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class ViewCourseAssignController : Controller
    {
        ViewCourseAssignGateway viewCourseAssignGateway = new ViewCourseAssignGateway();
        DepartmentManager departmentManager = new DepartmentManager();
        public ActionResult ViewAssignCourse()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var Courses = viewCourseAssignGateway.GetAllAssignCourse().Where(c=>c.DepartmentId == departmentId);
            return Json(Courses, JsonRequestBehavior.AllowGet);
        }
    }
}