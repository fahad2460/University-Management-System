using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.Controllers
{
    public class ClassScheduleController : Controller
    {
        ScheduleManager scheduleManager = new ScheduleManager();
        // GET: ClassSchedule
        public ActionResult ViewSchedule()
        {
            ViewBag.ShowDepartments = scheduleManager.GetAllDepartments();

            return View();
        }
    [HttpPost]
        public JsonResult ViewAllScheduleByDept(int departmentId)
        {
            var schedules = GetAllSchedule();
            var scheduleList = schedules.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(scheduleList, JsonRequestBehavior.AllowGet);
        
        }

        private List<ViewSchedule> GetAllSchedule()
        {
            List<ViewSchedule> allViewSchedules = scheduleManager.ViewAllSchedule();
            return allViewSchedules;

        }
    }
}