using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class DesignationManager
    {
        DesignationGateWay gateWay = new DesignationGateWay();
        public List<Designation> GetAllDesignation()
        {
            return gateWay.GetAllDesignation();
        }
    }
}