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
    public class CourseGateway
    {
        string connectionstrings = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;
        public int Save(CourseModel courseModel)
        {
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "INSERT INTO t_course VALUES(@code,@name,@credit,@description,@departmentid,@semesterid,@TeacherName)";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.Add("code", SqlDbType.VarChar);
            command.Parameters["code"].Value = courseModel.Code;
            command.Parameters.Add("name", SqlDbType.VarChar);
            command.Parameters["name"].Value = courseModel.Name;
            command.Parameters.Add("credit", SqlDbType.Decimal);
            command.Parameters["credit"].Value = courseModel.Credit;
            command.Parameters.Add("description", SqlDbType.VarChar);
            command.Parameters["description"].Value = courseModel.Description;
            command.Parameters.Add("departmentid", SqlDbType.Int);
            command.Parameters["departmentid"].Value = courseModel.Department;
            command.Parameters.Add("semesterid", SqlDbType.Int);
            command.Parameters["semesterid"].Value = courseModel.Semester;
            command.Parameters.Add("TeacherName", SqlDbType.VarChar);
            command.Parameters["TeacherName"].Value = "Not Assigned Yet";
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<CourseModel> GetAllcourse()
        {
            List<CourseModel> courses = new List<CourseModel>();
            SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "SELECT * FROM t_course";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               CourseModel courseModel = new CourseModel()
               {
                   Id = (int)reader["Id"],
                   Code = reader["Code"].ToString(),
                   Name = reader["Name"].ToString(),
                   Credit = Convert.ToDouble(reader["credit"]),
                   Description = reader["description"].ToString(),
                   Department = (int)reader["DepartmentId"],
                   Semester = (int)reader["semesterId"],
                   TeacherName = reader["TeacherName"].ToString()
               };
               
                courses.Add(courseModel);
            }
            reader.Close();
            connection.Close();
            return courses;
        }

        //public int Update(AssignModel assign)
        //{
           
        //}
        public int Update(AssignModel assign)
        {
           SqlConnection connection = new SqlConnection(connectionstrings);
            string query = "UPDATE t_course SET TeacherName = '" + assign.TeacherName + "' WHERE Id = '" +
                           assign.CourseId + "' ";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}