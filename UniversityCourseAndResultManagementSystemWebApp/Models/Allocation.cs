using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagementSystemWebApp.Models
{
    public class Allocation
    {
        //public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int DayId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllocationStatus { get; set; }

    }
}