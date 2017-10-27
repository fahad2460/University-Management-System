using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class CourseAssignController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager = new TeacherManager();
        CourseManager courseManager = new CourseManager();
        CourseAssignManager manager = new CourseAssignManager();

        
        public ActionResult Assign()
        {   
            
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult Assign(AssignModel assign, int departmentId)
        {

            ViewBag.message = manager.Save(assign);
            ViewBag.departments = departmentManager.GetAllDepartment();
            return View();
        }


        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teacherlist = teacherManager.GetAllteacher().Where(m=>m.DepartmentId == departmentId);
            return Json(teacherlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetailsByTeacherId(int teacherId)
        {
            var teacherlist = teacherManager.GetAllteacher().Find(m=>m.Id == teacherId);
            return Json(teacherlist, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = courseManager.GetAllcourses().Where(m => m.Department == departmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetailsByCourseId(int courseId)
        {
            var course = courseManager.GetAllcourses().Find(m => m.Id == courseId);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetValue(double reg, double credit)
        {
            var result = reg - credit;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}