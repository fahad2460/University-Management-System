using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class CourseAssignManager
    {
        CourseAssignGateway gateway = new CourseAssignGateway();
        TeacherGateWay gateWay = new TeacherGateWay();
        CourseGateway courseGateway = new CourseGateway();
        public string Save(AssignModel assign)
        {
            AssignModel isCourseExist = gateway.GetAllAssignCourses().Find(c=>c.CourseId == assign.CourseId && c.TeacherId==assign.TeacherId);
            if (isCourseExist != null)
            {
                return "This Course already assigned";
            }
            
            int rowAffected = gateway.Save(assign);

           
            if (rowAffected>0)
            {

                int rowAffected1 = gateWay.Update(assign);
                int rowAffected2 = courseGateway.Update(assign);
                if (rowAffected1>0)
                {
                    return "Assign Successfully"; 
                }
                else
                {
                    return "Insertion Failed";
                }
                
                
            }
            else
            {
                return "Insertion Failed";
            }

        }
    }
}