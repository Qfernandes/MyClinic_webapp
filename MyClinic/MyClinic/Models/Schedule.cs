using System;

namespace MyClinic.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public DateTime DateTime { get; set; }
        public Service? Service { get; set; }

        public paymentStatus? Paymentstatus { get; set; }

        public Treatmentpatient Treatmentpatient { get; set; }
        //public Treatment Treatment { get; set; }
        public Assistant Assistant { get; set; }
        public Patient Patient { get; set; }

        public Payment Payment { get; set; }


        //public int TreatmentpatientID { get; set; }
        //public int PatientID { get; set; }
        //public int PaymentID { get; set; }
        //public int AssistantID { get; set; }
    }
}