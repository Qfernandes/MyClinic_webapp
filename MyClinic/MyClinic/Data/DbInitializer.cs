using Microsoft.Data.SqlClient.Server;
using MyClinic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MyClinic.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyClinicContext context)
        {

            // Look for any patients.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var carryalex = new Patient
            {
                FullName = "Carry Alex",
                DOB = DateTime.Parse("2011-08-01"),
                Gender = "Male",
                ContactNumber = "0734567891",
                Email = "carrya@outlook.com",
                Address = "12 Kings Road",
                NextOfKin = "Father",
                MedicalHistory = "Diabetes"


            };
            var aronalonso = new Patient
            {
                FullName = "Aron Alonso",
                DOB = DateTime.Parse("2010-09-01"),
                Gender = "Male",
                ContactNumber = "0734557892",
                Email = "aron@outlook.com",
                Address = "15 Warwik Road",
                NextOfKin = "Mother",
                MedicalHistory = "Diabetes"


            };
            var pearlyanna = new Patient
            {
                FullName = "Pearly Anna",
                DOB = DateTime.Parse("2000-01-08"),
                Gender = "Female",
                ContactNumber = "0238797893",
                Email = "pearlan@outlook.com",
                Address = "15 Southampton Road",
                NextOfKin = "Father",
                MedicalHistory = "Asthma"


            };
            var garrybdukas = new Patient
            {
                FullName = "Garry Bdukas",
                DOB = DateTime.Parse("2006-09-01"),
                Gender = "Male",
                ContactNumber = "0234409894",
                Email = "bagarry@outlook.com",
                Address = "1 Queen Road",
                NextOfKin = "Sister",
                MedicalHistory = "none"


            };
            var yanimli = new Patient
            {
                FullName = "Yanim Li",
                DOB = DateTime.Parse("1999-09-01"),
                Gender = "Male",
                ContactNumber = "0799567895",
                Email = "yan@outlook.com",
                Address = "16 Carl Road",
                NextOfKin = "Father",
                MedicalHistory = "none"


            };
            var pasoljustin = new Patient
            {
                FullName = "Pasol Justin",
                DOB = DateTime.Parse("1990-11-01"),
                Gender = "Male",
                ContactNumber = "0736587896",
                Email = "pasol@outlook.com",
                Address = "18 Tilehurst Road",
                NextOfKin = "Sister",
                MedicalHistory = "Diabetes"


            };
            var laurannormani = new Patient
            {
                FullName = "Lauran Normani",
                DOB = DateTime.Parse("1998-03-01"),
                Gender = "Female",
                ContactNumber = "0734588897",
                Email = "laurann@ac.uk",
                Address = "129 Cumberland Road",
                NextOfKin = "Mother",
                MedicalHistory = "Asthma"


            };
            var ninaolli = new Patient
            {
                FullName = "Nina Olli",
                DOB = DateTime.Parse("2008-05-24"),
                Gender = "Female",
                ContactNumber = "0234564798",
                Email = "nina@outlook.com",
                Address = "11 Tuken Road",
                NextOfKin = "Brother",
                MedicalHistory = "Diabetes"
            };

            var patients = new Patient[]
            {
                carryalex,
                aronalonso,
                pearlyanna,
                garrybdukas,
                yanimli,
                pasoljustin,
                laurannormani,
                ninaolli
            };

            context.AddRange(patients);

            var cox = new Assistant
            {
                LastName = "Cox",
                FirstMidName = "James",
            };

            var helen = new Assistant
            {
                LastName = "Helen",
                FirstMidName = "Hendry",
            };

            var assistants = new Assistant[]
            {
                helen,
                cox
            };

            context.AddRange(assistants);

            /*
            if (contextt.Treatments.Any())
            {
                return;
            }
            */

            var Crowning = new Treatment
            {
                //TreatmentID = 1050,
                TreatmentName = "Crowning",
                Price = 100
            };

            var Braces = new Treatment
            {
                //TreatmentID = 4022,
                TreatmentName = "Braces",
                Price = 115
            };

            var Cleaning = new Treatment
            {
                //TreatmentID = 4041,
                TreatmentName = "Cleaning",
                Price = 75
            };

            var Dental = new Treatment
            {
                //TreatmentID = 1045,
                TreatmentName = "Dental",
                Price = 150
            };

            var Refill = new Treatment
            {
                //TreatmentID = 3141,
                TreatmentName = "Refill",
                Price = 70
            };

            var Treatments = new Treatment[]
            {
               Crowning, Braces, Cleaning, Dental, Refill
            };

            context.AddRange(Treatments);

            var treatmentpatients = new Treatmentpatient[]
            {
                new Treatmentpatient {
                    Patient = carryalex,
                    Service = Service.Crowning,
                    Price = 100,
                    // addPaymentstatus=Payment.PaymentStatus.Yes

                },
                new Treatmentpatient {
                    Patient = carryalex,
                    Service = Service.Dental,
                    Price = 150,
                    // add Paymentstatus=Payment.PaymentStatus.No

                },
                new Treatmentpatient {
                    Patient = aronalonso,
                    Service = Service.Dental,
                    Price = 150,
                    // add Paymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = pearlyanna,
                    Service = Service.Cleaning,
                    Price = 75,
                    //addPaymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = garrybdukas,
                    Service = Service.Braces,
                    Price = 115,
                    // add Paymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = yanimli,
                    Service = Service.Refill,
                    Price = 70,
                    // add Paymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = pasoljustin,
                    Service = Service.Refill,
                    Price = 70,
                    // add Paymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = laurannormani,
                    Service = Service.Braces,
                    Price = 115,
                    // add Paymentstatus=Payment.PaymentStatus.Yes
                },
                new Treatmentpatient {
                    Patient = ninaolli,
                    Service = Service.Crowning,
                    Price = 100,
                    //Paymentstatus=Payment.PaymentStatus.Yes
                },
            };
            context.AddRange(treatmentpatients);

            if (context.Payments.Any())
            {
                return;
            }

            var Payment1 = new Payment
            {
                Patient = carryalex,
                Service = Service.Crowning,
                paymentStatus = paymentStatus.no
            };
            var Payment2 = new Payment
           {
                Patient = carryalex,
                Service = Service.Dental,
                paymentStatus = paymentStatus.no
           };
            var Payment3 = new Payment
           {
                Patient = aronalonso,
                Service = Service.Dental,
                paymentStatus = paymentStatus.no
           };
            var Payment4 = new Payment
           {
                Patient = pearlyanna,
                Service = Service.Cleaning,
                paymentStatus = paymentStatus.no
           };
            var Payment5 = new Payment
           {
                Patient = garrybdukas,
                Service = Service.Braces,
                paymentStatus = paymentStatus.no
           };
            var Payment6 = new Payment
           {
                Patient = yanimli,
                Service = Service.Refill,
                paymentStatus = paymentStatus.no
           };
            var Payment7 = new Payment
           {
                Patient = pasoljustin,
                Service = Service.Refill,
                paymentStatus = paymentStatus.no
           };
            var Payment8 = new Payment
           {
                Patient = laurannormani,
                Service = Service.Braces,
                paymentStatus = paymentStatus.no
           };
            var Payment9 = new Payment
           {
                Patient = ninaolli,
                Service = Service.Crowning,
                paymentStatus = paymentStatus.no
           };
            var Payments = new Payment[]
            {
                Payment1,
                Payment2,
                Payment3,
                Payment4,
                Payment5,
                Payment6,
                Payment7,
                Payment8,
                Payment9
            };

            context.AddRange(Payments);

            /* var schedules = new Schedule[]
             {
                 new Schedule {
                     DateTime = DateTime.Parse("2023-08-01"),
                     Service = Service.Crowning,
                     Patient = carryalex,
                     Assistant = cox,
                     Paymentstatus=Payment.PaymentStatus.Yes


                 },*/
        }
     }
 }


//8 schedules
// 8 payments
//context.SaveChanges();
