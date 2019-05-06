using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PODBProjectWebApi.Models
{
    public class Employee
    {
        [Key]
        public string accountId { get; set; }
        public string employeeId { get; set; }
        public string employeeName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
    public class LoginEmployee
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class ChangePassword
    {
        public string email { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string confirmNewPassword { get; set; }
    }
}