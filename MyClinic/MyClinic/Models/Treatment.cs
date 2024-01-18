using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MyClinic.Models
{
    public class Treatment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TreatmentID { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "Treatment Name cannot be longer than 100 characters.")]
        [Column("TreatmentName")]
        [Display(Name = " Treatment Name")]
        public string TreatmentName { get; set; }
        public int Price { get; set; }
    }
}
