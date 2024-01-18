using System.ComponentModel.DataAnnotations.Schema;

namespace MyClinic.Models
{
    public class Treatment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TreatmentID { get; set; }
        public string TreatmentName { get; set; }
        public int Price { get; set; }
    }
}
