using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.BLL
{
    public class ViewResultManager
    {

        ViewResultGateway viewResultGateway = new ViewResultGateway();

        public List<StudentModel> GetRegNos()
        {
            return viewResultGateway.GetRegNos();
        }

        public List<StudentModel> GetStudentByRegNos(string RegNo)
        {
            return viewResultGateway.GetStudentByRegNos(RegNo);
        }

    }
}