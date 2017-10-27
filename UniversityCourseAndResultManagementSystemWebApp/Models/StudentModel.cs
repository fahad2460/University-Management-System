using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystemWebApp.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide an Email")]
        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Contact NO")]
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public int StudentId { get; set; }
        public string DepartmentName { get; set; }
        public string CourseName { get; set; }
        public string RegNo { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
        public int GradeId { get; set; }
        public string Code { get; set; }
    }
}