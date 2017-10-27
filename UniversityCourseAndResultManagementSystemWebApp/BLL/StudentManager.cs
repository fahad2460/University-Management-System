using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class StudentManager
    { 
        DepartmentManager manager = new DepartmentManager();
        StudentGatway gateway = new StudentGatway();
        public string Save(StudentModel student)
        {
            
            Department dept = manager.GetAllDepartment().Find(c=>c.Id == student.DepartmentId);
            string deptName = dept.Code;
            var studentCount = gateway.GetAllStudent().Where(c => c.DepartmentId == student.DepartmentId & c.Date.Year == student.Date.Year);
            int count = studentCount.Count() + 1; 
            string regNo = deptName + "-" + student.Date.Year + "-" + count;
            StudentModel isExists = gateway.GetAllStudent().Find(c => c.Email == student.Email);
            if (isExists != null)
            {
                return "Email Number Already Exist";
            }
            int rowAffected = gateway.Save(student,regNo);
            if (rowAffected>0)
            {
                return "Register Successfully...And your Registration Number :" + regNo;
            }
            else
            {
                return "Insertion Failled";
            }
        }
    }
}