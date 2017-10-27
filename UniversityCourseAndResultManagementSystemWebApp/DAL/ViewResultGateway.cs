using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class ViewResultGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<StudentModel> GetRegNos()
        {
            List<StudentModel> regNos = new List<StudentModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select s.Id,s.RegNo from  t_StudentResult r join t_student s on r.StudentId=s.Id group by s.RegNo,s.Id";
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
            string query = "select s.Name,s.Email,c.Code,d.Name as DepartmentName,c.Name as CourseName,isnull (r.Grade, 'Not graded yet') as Grade from t_student s join t_department d on s.DepartmentId=d.Id join t_EnrollInCourse e on e.StudentId=s.Id join t_course c on c.Id=e.CourseId left join t_StudentResult r on r.CourseId=e.CourseId where s.RegNo='" + RegNo + "'";
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

                    Grade = reader["Grade"].ToString(),
                    Code = reader["Code"].ToString()
                };
                studentsinfo.Add(student);
            }

            reader.Close();
            connection.Close();
            return studentsinfo;
        }

    }
}