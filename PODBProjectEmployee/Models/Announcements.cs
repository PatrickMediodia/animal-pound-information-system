using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PODBProjectEmployee.Models
{
    public class Announcements
    {
        [Key]
        public String AnnounceId { get; set; }
        public String AnnounceTitle { get; set; }
        public String AnnounceText { get; set; }
        public String PhotoId { get; set; }
        public String EmployeeId { get; set; }
    }
}