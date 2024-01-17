using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MyClinic.Models.Payment;

namespace MyClinic.Models
{
    public enum Service
    {
        Braces, Cleaning, Crowning, Dental, Refill
    }

    public class Treatmentpatient
    {
        public int TreatmentpatientID { get; set; }
        public int Price { get; set; }

        [DisplayFormat(NullDisplayText = "No service")]
        public Service? Service { get; set; }

        [DisplayFormat(NullDisplayText = "No status")]

        // add payment public PaymentStatus? Paymentstatus { get; set; }


        // add public Payment Payment { get; set; }
        

        public Patient Patient { get; set; }

        //public ICollection<Schedule> Schedules { get; set; }
        //public ICollection<Payment> Payments { get; set; }
        //public Treatment Treatment { get; set; }
        //public int TreatmentID { get; set; }

    }
}