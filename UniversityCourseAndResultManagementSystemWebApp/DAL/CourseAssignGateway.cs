using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Microsoft.SqlServer.Server;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class CourseAssignGateway
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public int Save(AssignModel assign)
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "INSERT INTO t_courseassign VALUES('"+assign.DepartmentId+"','"+assign.TeacherId+"','"+assign.Credit+"','"+assign.CourseId+"',@IsActive)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@IsActive", 1);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<AssignModel> GetAllAssignCourses()
        {
            List<AssignModel> courses = new List<AssignModel>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_courseassign";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AssignModel model = new AssignModel()
                {
                    Id = (int)reader["Id"],
                    DepartmentId = (int)reader["DepartmentId"],
                    TeacherId = (int)reader["TeacherId"],
                    CourseId = (int)reader["CourseId"]
                };
                courses.Add(model);
            }
            reader.Close();
            connection.Close();
            return courses;

        }
    }
}