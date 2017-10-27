using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class SemesterManager
    {
        SemesterGateway gateway = new SemesterGateway();
        public List<Semester> GetAllSemester()
        {
            return gateway.GetAllSemester();
        }
    }
}