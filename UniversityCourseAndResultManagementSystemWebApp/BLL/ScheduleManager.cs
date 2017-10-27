using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class ScheduleManager
    {
        ViewScheduleGateway viewScheduleGateway = new ViewScheduleGateway();


        public List<ViewSchedule> ViewAllSchedule()
        {
            List<ViewSchedule> allschedule = viewScheduleGateway.ViewAllSchedule();
            return allschedule;

        }
        public List<Department> GetAllDepartments()
        {
            List<Department> allDepartments = viewScheduleGateway.GetAllDepartments();
            return allDepartments;

        }
    }
}