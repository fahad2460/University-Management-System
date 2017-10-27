using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagementSystemWebApp.DAL;
using UniversityCourseAndResultManagementSystemWebApp.Models;

namespace UniversityCourseAndResultManagementSystemWebApp.DAL
{
    public class DepartmentManager
    {
        DepartmentGateWay gateway = new DepartmentGateWay();
        public string Save(Department department)
        {
            Department isExistsCode = gateway.GetAllDepartment().Find(c=>c.Code == department.Code);
            if (isExistsCode != null)
            {
                return "Code Already Exists";
            }
            Department isExistsName = gateway.GetAllDepartment().Find(c => c.Name == department.Name);
            if (isExistsName != null)
            {
                return "Name Already Exists";
            }
            int rowaffected = gateway.Save(department);
            if (rowaffected>0)
            {
                return "Successfully Saved";
            }
            else
            {
                return "Insertion Failed";
            }
        }


        public List<Department> GetAllDepartment()
        {
           
            return gateway.GetAllDepartment();
        }
    }

    

}