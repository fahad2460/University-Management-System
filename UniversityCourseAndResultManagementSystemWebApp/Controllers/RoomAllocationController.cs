using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class RoomAllocationController : Controller
    {
        RoomManager roomManager = new RoomManager();
        // GET: RoomAllocation
        public ActionResult SaveRoom()
        {
            List<Department> allDepartments = roomManager.GetAllDepartments();
            ViewBag.ShowDept = allDepartments;
            ViewBag.ShowCourse = GetCourses();
            List<Room> allRooms = roomManager.GetAllRooms();
            ViewBag.ShowRoom = allRooms;
            List<Day> allDays = roomManager.GetAllDays();
            ViewBag.ShowDays = allDays;
            return View();
        }
        [HttpPost]
        public ActionResult SaveRoom(Allocation allocation)
        {
            List<Department> allDepartments = roomManager.GetAllDepartments();
            ViewBag.ShowDept = allDepartments;
            ViewBag.ShowCourse = GetCourses();
            List<Room> allRooms = roomManager.GetAllRooms();
            ViewBag.ShowRoom = allRooms;
            List<Day> allDays = roomManager.GetAllDays();
            ViewBag.ShowDays = allDays;
            ViewBag.Message = roomManager.SaveRoom(allocation);
            return View();
        }
        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = GetCourses();
            var studentList = courses.Where(a => a.Department == departmentId).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        private List<CourseModel> GetCourses()
        {
            List<CourseModel> allCourses = roomManager.GetAllCourses();
            return allCourses;

        }
    }
}