using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Antlr.Runtime.Misc;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class DepartmentGateWay
    {   string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;
        public int Save(Department department)
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "INSERT INTO t_department VALUES (@Code,@Name)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = department.Code;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = department.Name;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departmentList = new List<Department>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_department";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department()
                {
                    Id = (int)reader["Id"],
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };

                departmentList.Add(department);
            }

            reader.Close();
            connection.Close();
            return departmentList;
        }
    }
}