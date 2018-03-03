using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZerOneUniversityApp.BLL;
using ZerOneUniversityApp.Models;
using ZerOneUniversityApp.Context;

namespace ZerOneUniversityApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            //string message = "";

            //message = departmentManager.SaveDepartment(aDepartment);

            //ViewBag.Message = message;

            //return View();
            try
            {
                string message = departmentManager.SaveDepartment(aDepartment);
                ViewBag.Message = message;
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.InnerException.Message;
                return View();
                
            }
        }
        public ActionResult show()
        {

            IEnumerable<Department> departments = departmentManager.GetAllDepartment();
            ViewBag.DepartmentList = departments;
            return View();
        }

        public JsonResult IsDeptCodeExists(string DeptCode)
        {
            bool isDeptCodeExists = departmentManager.IsDepartmentCodeExist(DeptCode);

            if (isDeptCodeExists)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult IsDeptNameExists(string DeptName)
        {
            bool isDeptNameExists = departmentManager.IsDepartmentNameExist(DeptName);

            if (isDeptNameExists)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }
        }
    }
}
