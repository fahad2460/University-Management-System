using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class SaveResultManager
    {

        SaveResultGateway saveResultGateway = new SaveResultGateway();


        public List<StudentModel> GetRegNos()
        {
            return saveResultGateway.GetRegNos();
        }
        public List<StudentModel> GetGrades()
        {
            return saveResultGateway.GetGrades();
        }

        public List<StudentModel> GetStudentByRegNos(string RegNo)
        {
            return saveResultGateway.GetStudentByRegNos(RegNo);
        }

        public string SaveResult(StudentModel studentInformation)
        {
            if (GetResults().Find(a => a.CourseId == studentInformation.CourseId && a.StudentId == studentInformation
                .StudentId) != null)
            {
                return "Result Already Given";
            }
            int rowAffected = saveResultGateway.SaveResult(studentInformation);
            if (rowAffected > 0)
            {
                return "Saved";
            }
            else
            {
                return "Not Saved";
            }
        }

        public List<StudentModel> GetResults()
        {
            return saveResultGateway.GetResults();
        }




    }
}