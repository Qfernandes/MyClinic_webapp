using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MyClinic.Models
{


    public enum paymentStatus
    {
        yes, no

    }
    public class Payment
    {
        public int PaymentID { get; set; }

        [DisplayFormat(NullDisplayText = "No Status")]
        public paymentStatus? paymentStatus { get; set; }
        public Service? Service { get; set; }



        public Patient Patient { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
        public ICollection<Treatmentpatient> Treatmentpatients { get; set; }


    }



}
