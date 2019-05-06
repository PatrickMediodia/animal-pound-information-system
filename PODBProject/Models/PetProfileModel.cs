using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PODBProject.Models
{
    public class PetProfileModel
    {
        [Key]
        public int petId { get; set; }
        public String Id { get; set; }
        [Required]
        public String petName { get; set; }
        [Required]
        public String petType { get; set; }
        [Required]
        public String petBreed { get; set; }
        [Required]
        public String gender { get; set; }

        public String mChipStatus { get; set; }
        public String mChipId { get; set; }
        public String nueterStatus { get; set; }

        public int imageID { get; set; }

    }
}