using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystemWebApp.Models
{
    public class Teacher
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide A Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Provide an Email")]
        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Contact NO")]
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please select a Designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please select a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Credit To be taken")]
        [Required(ErrorMessage = "Type The amount of credit to be taken")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter Positive Number")]
        public double CreditToBeTaken { get; set; }

        public double Remaining { get; set; }
    }
}