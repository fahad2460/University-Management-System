using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class TeacherManager
    {
        TeacherGateWay gateWay = new TeacherGateWay();
        public string Save(Teacher teacher)
        {
            Teacher isExistsCode = gateWay.GetAllTeacher().Find(c => c.Email == teacher.Email);
            if (isExistsCode != null)
            {
                return "Email Already Exists";
            }
            int rowAffected = gateWay.Save(teacher);
            if (rowAffected>0)
            {
                return "Successfully Saved...";
            }
            else
            {
                return "Insertion Failed";
            }
        }

        public List<Teacher> GetAllteacher()
        {
            return gateWay.GetAllTeacher();
        }
    }
}