using MyClinic.Models;

namespace MyClinic.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyClinicContext context)
        {
            // Look for any students.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var patients = new Patient[]
            {
                new Patient{FullName = "Carry Alex",DOB = DateTime.Parse("2011-08-01"),Gender = "Male",ContactNumber = "0734567891",Email = "carrya@outlook.com",Address = "12 Kings Road",NextOfKin = "Father",MedicalHistory = "Diabetes"},
                new Patient{FullName = "Aron Alonso",DOB = DateTime.Parse("2010-09-01"),Gender = "Male",ContactNumber = "0734557892",Email = "aron@outlook.com",Address = "15 Warwik Road",NextOfKin = "Mother",MedicalHistory = "Diabetes"},
                new Patient{FullName = "Pearly Anna",DOB = DateTime.Parse("2000-01-08"),Gender = "Female",ContactNumber = "0238797893",Email = "pearlan@outlook.com",Address = "15 Southampton Road",NextOfKin = "Father",MedicalHistory = "Asthma"},
                new Patient{FullName = "Garry Bdukas",DOB = DateTime.Parse("2006-09-01"),Gender = "Male",ContactNumber = "0234409894",Email = "bagarry@outlook.com",Address = "1 Queen Road",NextOfKin = "Sister",MedicalHistory = "none"},
                new Patient{FullName = "Yanim Li",DOB = DateTime.Parse("1999-09-01"),Gender = "Male",ContactNumber = "0799567895",Email = "yan@outlook.com",Address = "16 Carl Road",NextOfKin = "Father",MedicalHistory = "none"},
                new Patient{FullName = "Pasol Justin",DOB = DateTime.Parse("1990-11-01"),Gender = "Male",ContactNumber = "0736587896",Email = "pasol@outlook.com",Address = "18 Tilehurst Road",NextOfKin = "Sister",MedicalHistory = "Diabetes"},
                new Patient{FullName = "Lauran Normani",DOB = DateTime.Parse("1998-03-01"),Gender = "Female",ContactNumber = "0734588897",Email = "laurann@ac.uk",Address = "129 Cumberland Road",NextOfKin = "Mother",MedicalHistory = "Asthma"},
                new Patient{FullName = "Nina Olli",DOB = DateTime.Parse("2008-05-24"),Gender = "Female",ContactNumber = "0234564798",Email = "nina@outlook.com",Address = "11 Tuken Road",NextOfKin = "Brother",MedicalHistory = "Diabetes"},

            };

            context.Patients.AddRange(patients);
            context.SaveChanges();

            if (context.Treatments.Any())
            {
                return;
            }

            var Crowning = new Treatment
            {
                TreatmentID = 1050,
                TreatmentName = "Crowning",
                Price = 100
            };

            var Braces = new Treatment
            {
                TreatmentID = 4022,
                TreatmentName = "Braces",
                Price = 115
            };

            var Cleaning = new Treatment
            {
                TreatmentID = 4041,
                TreatmentName = "Cleaning",
                Price = 75
            };

            var Dental = new Treatment
            {
                TreatmentID = 1045,
                TreatmentName = "Dental",
                Price = 150
            };

            var Refill = new Treatment
            {
                TreatmentID = 3141,
                TreatmentName = "Refill",
                Price = 70
            };




            context.SaveChanges();

        }


    }
}