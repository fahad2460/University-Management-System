using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class TeacherController : Controller
    { 
        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();
        TeacherManager teacherManager = new TeacherManager();

        public ActionResult Save()
        {
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.designations = designationManager.GetAllDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            ViewBag.message = teacherManager.Save(teacher);
            ViewBag.departments = departmentManager.GetAllDepartment();
            ViewBag.designations = designationManager.GetAllDesignation();
            return View();
        }
	}
}