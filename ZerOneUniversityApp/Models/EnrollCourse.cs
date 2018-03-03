﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZerOneUniversityApp.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Student By Registration Number")]
        [Display(Name = "Student Reg. No.")]
        public string RegistrationNo { get; set; } 
        public virtual Student Student { get; set; }


        [Required(ErrorMessage = "Please Select  Course")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }


        [Required(ErrorMessage = "Enter Enroll Date")]
        [Display(Name = "Date")]
        public DateTime EnrollDate { get; set; }

        public string CourseGrade { get; set; }
    }
}