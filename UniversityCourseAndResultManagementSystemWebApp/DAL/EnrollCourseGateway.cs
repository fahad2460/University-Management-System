using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class EnrollCourseGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<StudentModel> GetRegNos()
        {
            List<StudentModel> regNos = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_student";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel reg = new StudentModel
                {
                    RegNo = reader["RegNo"].ToString(),
                    Id = (int)reader["Id"]
                };
                regNos.Add(reg);
            }
            reader.Close();
            connection.Close();
            return regNos;
        }

        public List<StudentModel> GetStudentByRegNos(string RegNo)
        {
            List<StudentModel> studentsinfo = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select s.Name,s.Email,d.Name as DepartmentName,c.Id,c.Name as CourseName,s.Id as StudentId from t_student s join t_department d on d.Id=s.DepartmentId join t_course c on c.DepartmentId=d.Id where s.RegNo='" + RegNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel student = new StudentModel
                {
                    Name = reader["Name"].ToString(),
                    CourseName = reader["CourseName"].ToString(),
                    Email = reader["Email"].ToString(),
                    DepartmentName = reader["DepartmentName"].ToString(),
                    CourseId = (int)reader["Id"],
                    Id = (int)reader["StudentId"]

                };
                studentsinfo.Add(student);
            }

            reader.Close();
            connection.Close();
            return studentsinfo;
        }

        public List<EnrollCourse> GetCourses()
        {
            List<EnrollCourse> enrollCourses = new List<EnrollCourse>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_EnrollInCourse";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EnrollCourse enrollCourse = new EnrollCourse
                {

                    CourseId = (int)reader["CourseId"],
                    StudentId = (int)reader["StudentId"],
                    Date = (DateTime)reader["Date"]

                };
                enrollCourses.Add(enrollCourse);
            }

            reader.Close();
            connection.Close();
            return enrollCourses;
        }

        public int EnrollInCourse(EnrollCourse enrollCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_EnrollInCourse(StudentId,CourseId,Date,IsStudentActive) VALUES(@StudentId,@CourseId,@Date,@IsStudentActive)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", enrollCourse.StudentId);
            command.Parameters.AddWithValue("@CourseId", enrollCourse.CourseId);
            command.Parameters.AddWithValue("@Date", enrollCourse.Date);
            command.Parameters.AddWithValue("@IsStudentActive", 1);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }


    }
}