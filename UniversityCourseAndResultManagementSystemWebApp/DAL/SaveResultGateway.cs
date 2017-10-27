using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class SaveResultGateway
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
            string query = "select s.Id as StudentId, s.Name,s.Email,d.Name as DepartmentName,c.Name as CourseName,c.Id as Id from t_student s join t_EnrollInCourse e on e.StudentId=s.Id join t_department d on s.DepartmentId=d.Id join t_course c on c.Id=e.CourseId where s.RegNo='" + RegNo + "'";
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
        public List<StudentModel> GetGrades()
        {
            List<StudentModel> grades = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_Grade";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel grade = new StudentModel
                {
                    Grade = reader["Grade"].ToString(),
                    GradeId = (int)reader["Id"]

                };
                grades.Add(grade);
            }
            reader.Close();
            connection.Close();
            return grades;
        }

        public int SaveResult(StudentModel studentInformation)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_StudentResult(StudentId,CourseId,Grade) VALUES(" + studentInformation.Id + "," + studentInformation.CourseId + ",'" + studentInformation.Grade + "')";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        public List<StudentModel> GetResults()
        {
            List<StudentModel> results = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_StudentResult";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StudentModel result = new StudentModel
                {
                  CourseId = (int)reader["CourseId"],
                    StudentId = (int)reader["StudentId"],
                    Grade = reader["Grade"].ToString()
                };
                results.Add(result);
            }
            reader.Close();
            connection.Close();
            return results;
        }


    }
}