using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class RoomManager
    {

        RoomAllocationGateway roomAllocationGateway = new RoomAllocationGateway();

        public List<Department> GetAllDepartments()
        {
            List<Department> allDepartments = roomAllocationGateway.GetAllDepartments();
            return allDepartments;

        }

        public List<CourseModel> GetAllCourses()
        {
            List<CourseModel> allCourses = roomAllocationGateway.GetAllCourses();
            return allCourses;

        }

        public List<Day> GetAllDays()
        {
            List<Day> allDays = roomAllocationGateway.GetAllDays();
            return allDays;

        }

        public List<Room> GetAllRooms()
        {
            List<Room> allRooms = roomAllocationGateway.GetAllRooms();
            return allRooms;

        }

        //public string SaveRoom(Allocation allocation)
        //{
        //    bool isTimeScheduleValid = IsTimeScheduleValid(allocation.RoomId, allocation.DayId, allocation.StartTime, allocation.EndTime);
        //    if (isTimeScheduleValid)
        //    {
        //        if (roomAllocationGateway.SaveRoom(allocation) > 0)
        //        {
        //            return "Saved Sucessfully!";
        //        }
        //        return "Failed to save";

        //    }
        //    return "Overlapping not allowed";


        //}

        //private bool IsTimeScheduleValid(int roomId, int dayId, DateTime startTime, DateTime endTime)
        //{
        //    List<Allocation> schedule = roomAllocationGateway.GetClassSchedulByStartAndEndingTime(roomId, dayId, startTime, endTime);
        //    if (schedule.Count == 0)
        //    {

        //            return true;    



        //    }
        //    return false;
        //}

        public string SaveRoom(Allocation allocation)
        {
            string msg;
            List<Allocation> checckAllocations = roomAllocationGateway.GetAllocations()
                .Where(
                    x =>
                        x.RoomId == allocation.RoomId && x.DayId == allocation.DayId
                )
                .ToList();
            if (checckAllocations.Count > 0)
            {
                List<Allocation> checkTime=roomAllocationGateway.GetAllocations()
                        .Where(x => allocation.StartTime==x.StartTime).ToList();
                if (checkTime.Count>0)
                {
                    msg= "Time Slot not Available";
                }
                else
                {
                    roomAllocationGateway.SaveRoom(allocation);
                    msg = "saved";    
                }
                
            }
            else
            {
                if (roomAllocationGateway.SaveRoom(allocation) > 0)
                {
                   msg= "Allocation Succesfull";
                }

                else
                {
                    msg= "Allocation Failed";
                }

            }
            return msg;


        }

    }
}
