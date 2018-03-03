using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ZerOneUniversityApp.Models;
using ZerOneUniversityApp.Context;


namespace ZerOneUniversityApp.Controllers
{
    public class CourseAssignController : Controller
    {
        private UniversityDBContext db = new UniversityDBContext();

        public ActionResult ViewCourseStatistics()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        public JsonResult ShowCourseStatistics(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        // GET: /CourseAssign/Create
        public ActionResult Save()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseCode");
            //ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode");
            //ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName");

            ViewBag.Departments = db.Departments.ToList();

            return View();
        }

        public JsonResult GetTeacherByDeptId(int deptId)
        {
            var teachers = db.Teachers.Where(m => m.DepartmentId == deptId).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByDeptId(int deptId)
        {
            var courses = db.Courses.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherById(int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(m => m.Id == teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int courseId)
        {
            Course aCourse = db.Courses.FirstOrDefault(m => m.Id == courseId);
            return Json(aCourse, JsonRequestBehavior.AllowGet);
        }

        // POST: /CourseAssign/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,DepartmentId,TeacherId,CreditTaken,CreditLeft,CourseId,Name,Credit")] CourseAssign courseassign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseassign);
                db.SaveChanges();
                ViewBag.Message = "Course Assigned Successful";

                //  return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "Id", "CourseCode", courseassign.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DeptCode", courseassign.DepartmentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "TeacherName", courseassign.TeacherId);
            return View(courseassign);
        }


        public JsonResult SaveCourseAssign(CourseAssign courseAssign)
        {
            var checkAssignedCoueses =
                db.CourseAssigns.Where(m => m.CourseId == courseAssign.CourseId && m.Course.CourseStatus == true)
                    .ToList();

            if (checkAssignedCoueses.Count > 0)
                return Json(false);

            else
            {
                db.CourseAssigns.Add(courseAssign);
                db.SaveChanges();

                var teacher = db.Teachers.FirstOrDefault(m => m.Id == courseAssign.TeacherId);

                if (teacher != null)
                {
                    teacher.CreditLeft = courseAssign.CreditLeft;
                    db.Teachers.AddOrUpdate(teacher);
                    db.SaveChanges();

                    var course = db.Courses.FirstOrDefault(m => m.Id == courseAssign.CourseId);

                    if (course != null)
                    {
                        course.CourseStatus = true;
                        course.CourseAssignTo = teacher.TeacherName;
                        db.Courses.AddOrUpdate(course);
                        db.SaveChanges();

                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                else
                {
                    return Json(false);
                }
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    }





