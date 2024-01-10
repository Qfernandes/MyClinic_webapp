using System;
using MyClinic.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyClinic.Models
{
    public class Patient
    {
        public int PatientID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Full Name cannot be longer than 100 characters.")]
        [Column("FullName")]
        [Display(Name = " Patient Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DOB ")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Invalid Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Next of Kin cannot be longer than 100 characters.")]
        [Display(Name = "NextOfKin")]
        public string NextOfKin { get; set; }
        public string MedicalHistory { get; set; }





    }

}
