using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystemWebApp.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public int  Department { get; set; }
        public int Semester { get; set; }
        public string TeacherName { get; set; }
    }
}