using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZerOneUniversityApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Teacher Name") ]
        [DisplayName("Name")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Enter Teacher Address")]
        [DisplayName("Address")]
        [DataType(DataType.MultilineText)]
        public string TeacherAddress { get; set; }

        [Required(ErrorMessage = "Enter Valid Email Address")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid Email! Must Be Enter Valid Email Address.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail is not valid")]
        [Remote("IsEmailExists", "Teacher", ErrorMessage = "Email Address already exists!")]
        public string TeacherEmail { get; set; }

        [Required(ErrorMessage = "Enter a Valid Phone Number")]
        [DisplayName("Contact No.")]
        [Phone]
        [StringLength(14, MinimumLength = 7, ErrorMessage = "Invalid Phone Number")]
        public string TeacherContactNo { get; set; }

        [Required(ErrorMessage ="Select A Designation" )]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        [Required(ErrorMessage = "Select Department")]
        [DisplayName ("Department")]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Negative Credit Not Allow ! Enter Positive Credit Number")]
        [DisplayName ("Credit to be Taken")]
        public double CreditTaken { get; set; }

        public double CreditLeft { get; set; }
    }
}