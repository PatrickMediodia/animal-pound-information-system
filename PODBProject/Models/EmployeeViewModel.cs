using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PODBProject.Models
{
    public class EmployeeViewModel
    {
        public class AnnouncementModel
        {
            [Key]
            public int announceId { get; set; }
            public string announceTitle { get; set; }
            public string announceText { get; set; }
            public int imageID { get; set; }
            public string announceDate { get; set; }
            public string Id { get; set; }
        }
    }
}