using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class DesignationGateWay
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<Designation> GetAllDesignation()
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_designation";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            List<Designation> designations = new List<Designation>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Designation designation = new Designation()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
                designations.Add(designation);
            }
            reader.Close();
            connection.Close();
            return designations;
        }
    }
}