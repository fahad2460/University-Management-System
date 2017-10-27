using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;

namespace UniversityCourseAndResultManagementSystemWebApp.BLL
{
    public class UnAssignManager
    {
        UnAssignGateway unAssignGateway = new UnAssignGateway();

        public string UnAssignAll()
        {
            if (unAssignGateway.UnAssignCourse() > 0 && unAssignGateway.UnAssignStudentCourse() > 0)
            {
                return "Unassign courses Sucessfull!";
            }
            return "Failed to unassign";
        }
    }
}