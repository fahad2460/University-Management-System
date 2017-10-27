using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager = new SemesterManager();
        CourseManager courseManager = new CourseManager();
        [HttpPost]
        public ActionResult Save(CourseModel courseModel)
        {
            ViewBag.message = courseManager.Save(courseModel);
            ViewBag.semester = semesterManager.GetAllSemester();
            ViewBag.department = departmentManager.GetAllDepartment();
            return View();
        }

        public ActionResult Save()
        {
            ViewBag.semester = semesterManager.GetAllSemester();
            ViewBag.department = departmentManager.GetAllDepartment();
            return View();
        }

	}
}