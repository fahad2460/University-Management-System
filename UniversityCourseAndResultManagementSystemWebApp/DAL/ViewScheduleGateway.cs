using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class ViewScheduleGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_department";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),


                };
                departments.Add(department);
            }

            reader.Close();
            connection.Close();
            return departments;
        }


        public List<ViewSchedule> ViewAllSchedule()
        {
            List<ViewSchedule> allocatedschedules = new List<ViewSchedule>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ViewClassSchedule";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ViewSchedule viewSchedule = new ViewSchedule
                {
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    DayName = reader["DayName"].ToString(),
                    RoomName = reader["RoomName"].ToString(),
                    StartTime = Convert.ToDateTime(reader["StartTime"].ToString()),
                    EndTime = Convert.ToDateTime(reader["EndTime"].ToString()),
                    DepartmentId = (int)reader["DepartmentId"]

                };
                allocatedschedules.Add(viewSchedule);
            }

            reader.Close();
            connection.Close();
            return allocatedschedules;
        }

    }
}