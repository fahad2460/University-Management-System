using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class ViewCourseAssignGateway
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<ViewCourseModel> GetAllAssignCourse()
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_courses";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            List<ViewCourseModel> viewCourses = new List<ViewCourseModel>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ViewCourseModel course = new ViewCourseModel()
                {
                    DepartmentId = (int)reader["DepartmentId"],
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Semester = reader["Semester"].ToString(),
                    TeacherName = reader["TeacherName"].ToString()
                };
                viewCourses.Add(course);
            }
            reader.Close();
            connection.Close();
            return viewCourses;
        }

    }

}