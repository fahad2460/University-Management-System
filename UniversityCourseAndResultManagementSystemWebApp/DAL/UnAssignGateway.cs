using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class UnAssignGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public int UnAssignCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE dbo.t_courseassign SET IsActive=0";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            //int a = teacherGateway.UpdateTeacherInformation();

            connection.Close();
            return rowAffected;


        }
        public int UnAssignStudentCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_EnrollInCourse SET IsStudentActive=0";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int anotherRowAffected= command.ExecuteNonQuery();
            return anotherRowAffected;
        }
    }
}