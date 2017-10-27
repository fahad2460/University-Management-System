using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class StudentGatway
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;
        public int Save(StudentModel student, string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "INSERT INTO t_student VALUES(@name,@email,@contactNo,@date,@address,@departmentId,@RegNo)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = student.Name;
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = student.Email;
            command.Parameters.Add("contactNo", SqlDbType.VarChar);
            command.Parameters["contactNo"].Value = student.ContactNo;
            command.Parameters.Add("date", SqlDbType.Date);
            command.Parameters["date"].Value = student.Date;
            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = student.Address;
            command.Parameters.Add("departmentId", SqlDbType.VarChar);
            command.Parameters["departmentId"].Value = student.DepartmentId;
            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = regNo;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;


        }

        public List<StudentModel> GetAllStudent()
        {
            List<StudentModel> students = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_student";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel student = new StudentModel()
                {
                   Id = (int)reader["Id"],
                   Name = reader["Name"].ToString(),
                   Email = reader["Email"].ToString(),
                   ContactNo = reader["ContactNo"].ToString(),
                   Date = Convert.ToDateTime(reader["Date"]),
                   Address = reader["Address"].ToString(),
                   DepartmentId = (int)reader["DepartmentId"],
                   RegNo = reader["RegNo"].ToString()
                };
                students.Add(student);


            }
            reader.Close();
            connection.Close();
            return students;
        }
    }
}