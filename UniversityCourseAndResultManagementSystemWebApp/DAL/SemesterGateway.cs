using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class SemesterGateway
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;
        public List<Semester> GetAllSemester()
        {
            List<Semester> semesters = new List<Semester>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_semester";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Semester semester = new Semester()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                    
                };

                semesters.Add(semester);
            }
            reader.Close();
            connection.Close();
            return semesters;
        }
        
    }
}