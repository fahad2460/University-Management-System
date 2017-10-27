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
    public class TeacherGateWay
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public int Save(Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "INSERT INTO t_teacher VALUES (@name,@address,@email,@contactNo,@designationId,@departmentId,@credit,@remaining)";
            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = teacher.Name;
            command.Parameters.Add("address", SqlDbType.VarChar);
            command.Parameters["address"].Value = teacher.Address;
            command.Parameters.Add("email", SqlDbType.VarChar);
            command.Parameters["email"].Value = teacher.Email;
            command.Parameters.Add("contactNo", SqlDbType.VarChar);
            command.Parameters["contactNo"].Value = teacher.ContactNo;
            command.Parameters.Add("designationId", SqlDbType.Int);
            command.Parameters["designationId"].Value = teacher.DesignationId;
            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = teacher.DepartmentId;
            command.Parameters.Add("credit", SqlDbType.Decimal);
            command.Parameters["credit"].Value = teacher.CreditToBeTaken;
            command.Parameters.Add("remaining", SqlDbType.Decimal);
            command.Parameters["remaining"].Value = teacher.CreditToBeTaken;

            connection.Open();
            int rowaffected = command.ExecuteNonQuery();
            connection.Close();
            return rowaffected;
        }


        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_teacher";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int)reader["Id"],
                    Name = reader["name"].ToString(),
                    Address = reader["Address"].ToString(),
                    Email = reader["Email"].ToString(),
                    ContactNo = reader["contactNo"].ToString(),
                    DesignationId = (int)reader["designationId"],
                    DepartmentId = (int)reader["departmentId"],
                    CreditToBeTaken = Convert.ToDouble(reader["credit"]),
                    Remaining = Convert.ToDouble(reader["remaining"])
                    
                };
                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teachers;
        }

        public int Update(AssignModel assign)
        {
            double credit = assign.RemainingCredit - assign.Credit;
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "UPDATE t_teacher SET remaining = '" + credit + "' WHERE Id = '" + assign.TeacherId + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;

        }
    }
}