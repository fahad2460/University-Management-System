using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class DepartmentController : Controller
    {   
        DepartmentManager manager = new DepartmentManager();
        [HttpPost]
        public ActionResult Save(Department department)
        {
            ViewBag.Message = manager.Save(department);
            return View();
        }

        public ActionResult Save()
        {
            return View();
        }

        public ActionResult ViewDepartment()
        {
            List<Department> departments = manager.GetAllDepartment();
            return View(departments);
        }

	}
}