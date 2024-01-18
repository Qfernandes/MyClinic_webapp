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
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 characters.")]
        [Display(Name = "ContactNumber")]
        
        public string ContactNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Next of Kin cannot be longer than 100 characters.")]
        [Display(Name = "NextOfKin")]
        public string NextOfKin { get; set; }
        public string MedicalHistory { get; set; }

        public ICollection<Treatmentpatient> Treatmentpatients { get; set; }

       // public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

}
