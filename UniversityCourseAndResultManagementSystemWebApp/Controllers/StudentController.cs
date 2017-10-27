using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        public ActionResult Save()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Save(StudentModel student)
        {
            ViewBag.message = studentManager.Save(student);
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }


	}
}