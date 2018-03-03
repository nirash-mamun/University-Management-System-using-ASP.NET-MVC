using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZerOneUniversityApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required ]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Remote("IsEmailExists", "Student", ErrorMessage = "Email already exists!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "The Field Contact No is Mandatory.")]
        [Phone(ErrorMessage = "Contact No format is Incorrect.")]
        [StringLength(14, MinimumLength = 7, ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "The Field Date is Mandatory.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        [Required]
        [DataType(DataType.MultilineText)]

        public string Address { get; set; }

        [Required(ErrorMessage = "The Field Department is Mandatory.")]
        [DisplayName("Department")]

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public string StudentRegNo { get; set; } // Auto Generated
    }
}