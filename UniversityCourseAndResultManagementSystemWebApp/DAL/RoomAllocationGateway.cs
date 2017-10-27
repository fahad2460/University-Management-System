using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class RoomAllocationGateway
    {

        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityconnStrings"].ConnectionString;

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_department";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department department = new Department
                {
                    Id = (int) reader["Id"],
                    Name = reader["Name"].ToString(),


                };
                departments.Add(department);
            }

            reader.Close();
            connection.Close();
            return departments;
        }

        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_course";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CourseModel course = new CourseModel
                {
                    Id = (int) reader["Id"],
                    Name = reader["Name"].ToString(),
                    Department = Convert.ToInt32(reader["DepartmentId"])


                };
                courses.Add(course);
            }

            reader.Close();
            connection.Close();
            return courses;
        }

        public List<Day> GetAllDays()
        {
            List<Day> days = new List<Day>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_day";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Day day = new Day
                {
                    Id = (int) reader["Id"],
                    DayName = reader["DayName"].ToString(),



                };
                days.Add(day);
            }

            reader.Close();
            connection.Close();
            return days;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_room";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Room room = new Room
                {
                    Id = (int) reader["Id"],
                    RoomName = reader["RoomName"].ToString(),



                };
                rooms.Add(room);
            }

            reader.Close();
            connection.Close();
            return rooms;
        }

        public int SaveRoom(Allocation allocation)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query =
                "INSERT INTO t_AllocateClassRoom VALUES(@DepartmentId,@CourseId,@RoomId,@DayId,@StartTime,@EndTime,@AllocationStatus)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseId", allocation.CourseId);
            command.Parameters.AddWithValue("@DayId", allocation.DayId);
            command.Parameters.AddWithValue("@DepartmentId", allocation.DepartmentId);
            command.Parameters.AddWithValue("@RoomId", allocation.RoomId);
            command.Parameters.AddWithValue("@StartTime", allocation.StartTime.ToShortTimeString());
            command.Parameters.AddWithValue("@EndTime", allocation.EndTime.ToShortTimeString());
            command.Parameters.AddWithValue("@AllocationStatus", 1);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            return rowAffected;
        }

        //public List<Allocation> GetClassSchedulByStartAndEndingTime(int roomId, int dayId, DateTime startTime, DateTime endTime)
        //{
        //    List<Allocation> schedulebytime = new List<Allocation>();
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "Select * from t_AllocateClassRoom where  StartTime BETWEEN CAST('" + startTime + "' As Time) AND CAST('" + endTime + "' As Time) AND RoomId ='" + roomId +
        //                                 "' AND DayId='" + dayId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Allocation schedule = new Allocation
        //        {

        //            DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
        //            CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
        //            RoomId = Convert.ToInt32(reader["RoomId"].ToString()),
        //            DayId = Convert.ToInt32(reader["DayId"].ToString()),
        //            StartTime = Convert.ToDateTime(reader["StartTime"]),
        //            EndTime = Convert.ToDateTime(reader["EndTime"])



        //        };
        //        schedulebytime.Add(schedule);
        //    }

        //    reader.Close();
        //    connection.Close();
        //    return schedulebytime;
        //}


        public List<Allocation> GetAllocations()
        {
            List<Allocation> allAllocations = new List<Allocation>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select DepartmentId,CourseId,RoomId,DayId, Cast(StartTime as datetime) as StartTime,CAST (EndTime as datetime) as EndTime from t_AllocateClassRoom";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Allocation allocation = new Allocation
                {
                    DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString()),
                    CourseId = Convert.ToInt32(reader["CourseId"].ToString()),
                    RoomId = Convert.ToInt32(reader["RoomId"].ToString()),
                    DayId = Convert.ToInt32(reader["DayId"].ToString()),
                    StartTime = Convert.ToDateTime (reader["StartTime"]),
                    EndTime = Convert.ToDateTime(reader["EndTime"])
                };
                allAllocations.Add(allocation);

            }
            reader.Close();
            connection.Close();
            return allAllocations;
        }
    }
}