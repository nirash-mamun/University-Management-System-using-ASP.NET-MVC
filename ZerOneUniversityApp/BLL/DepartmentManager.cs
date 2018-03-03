using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZerOneUniversityApp.DAL;
using ZerOneUniversityApp.Models;

namespace ZerOneUniversityApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public string SaveDepartment(Department aDepartment)
        {
            string message = "";

            if (departmentGateway.IsDepartmentCodeExist(aDepartment.DeptCode))
                message = "Department Code Exist";

            else if (departmentGateway.IsDepartmentNameExist(aDepartment.DeptName))
            {
                message = "Department Name Exist";
            }
            else 
            {
                int rowAffected = departmentGateway.SaveDepartment(aDepartment);

                if (rowAffected > 0)
                    message = "Department Saved Successfully.";
                else
                    message = " Department Save Failed !!";
            }
            return message;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = departmentGateway.GetAllDepartment();
            return departments;
        }

        public bool IsDepartmentCodeExist(string DeptCode)
        {
            return departmentGateway.IsDepartmentCodeExist(DeptCode);
        }

        public bool IsDepartmentNameExist(string DeptName)
        {
            return departmentGateway.IsDepartmentNameExist(DeptName);
        }
    }
}