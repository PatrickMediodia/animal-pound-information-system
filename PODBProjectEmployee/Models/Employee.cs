using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PODBProjectEmployee.Models
{
    public class Employee
    {
        [Key]
        public string accountId { get; set; }
        [Required]
        [Display(Name = "Employee ID")]
        public string employeeId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string employeeName { get; set; }
        [Required]
        [Display(Name = "Employee Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("password")]
        public string confirmPassword { get; set; }
    }
    public class Login
    {
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
    public class ChangePassword
    {
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]
        [Display(Name = "New Password")]
        public string newPassword { get; set; }
        [Required]
        [Display(Name = "Confirm new Password")]
        [Compare("newPassword")]
        public string confirmNewPassword { get; set; }
    }

}