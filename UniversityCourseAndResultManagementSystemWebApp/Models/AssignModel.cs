using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace UniversityCourseAndResultManagementSystemWebApp.Models
{
    public class AssignModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public double RemainingCredit { get; set; }
        public double Credit { get; set; }
        public int CourseId { get; set; }
        public bool IsActive { get; set; }
        
    }
}