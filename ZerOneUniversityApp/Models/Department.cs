﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZerOneUniversityApp.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter a Valid Department Code")]
        [Display(Name = "Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Departmrnt Code Must be 2 to  7 characters long")]
        [Remote("IsDeptCodeExists", "Department", ErrorMessage = "Code already exists!")]
        public string DeptCode { get; set; }


        [Required(ErrorMessage = "Please Enter a Valid Department Name!")]
        [Display(Name = "Name")]
        [Remote("IsDeptNameExists", "Department", ErrorMessage = "Name already exists!")]
        public string DeptName { get; set; }
    }
}