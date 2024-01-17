
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyClinic.Models
{
    public class Assistant
    {
        public int AssistantID { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstMidName")]
        [Display(Name = "Assistant Name")]
        [StringLength(50)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        //public ICollection<Schedule> Schedules { get; set; }
    }
}
