using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();
        public List<StudentModel> GetRegNos()
        {
            return enrollCourseGateway.GetRegNos();
        }

        public List<StudentModel> GetStudentByRegNos(string RegNo)
        {
            return enrollCourseGateway.GetStudentByRegNos(RegNo);
        }
        public string EnrollInCourse(EnrollCourse enrollCourse)
        {
            if (GetCourses(enrollCourse.StudentId).Find(a => a.StudentId == enrollCourse.StudentId && a.CourseId == enrollCourse
                .CourseId) != null)
            {
                return "Already Enrolled";
            }
            int rowAffected = enrollCourseGateway.EnrollInCourse(enrollCourse);
            if (rowAffected > 0)
            {
                return "Saved";
            }
            else
            {
                return "Not Saved";
            }


        }

        public List<EnrollCourse> GetCourses(int studentId)
        {
            List<EnrollCourse> getCourses = enrollCourseGateway.GetCourses();
            return getCourses;
        }
    }
}