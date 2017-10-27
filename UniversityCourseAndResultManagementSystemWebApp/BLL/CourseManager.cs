using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class CourseManager
    {
        CourseGateway gateway = new CourseGateway();
        public string  Save(CourseModel courseModel)
        {
            CourseModel iscodeExist = gateway.GetAllcourse().Find(c=>c.Code == courseModel.Code);
            if (iscodeExist != null)
            {
                return "Code already exist...";
            }

            CourseModel isNameExist = gateway.GetAllcourse().Find(c => c.Name == courseModel.Name);
            if (isNameExist != null)
            {
                return "Name already exist...";
            }

            int rowAffected = gateway.Save(courseModel);
            if (rowAffected>0)
            {
                return "Successfully Saved...";
            }
            else
            {
                return "Insertion Failed";
            }
        }

        public List<CourseModel> GetAllcourses()
        {
            return gateway.GetAllcourse();
        }
    }
}