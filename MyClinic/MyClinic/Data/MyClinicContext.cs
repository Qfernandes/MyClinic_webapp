using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyClinic.Models;


namespace MyClinic.Data
{
    public class MyClinicContext : DbContext
    {
        public MyClinicContext (DbContextOptions<MyClinicContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Treatmentpatient> Treatmentpatients { get; set; }
        public DbSet<Assistant> Assistants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Treatment>().ToTable("Treatment");
        modelBuilder.Entity<Treatmentpatient>().ToTable("Treatmentpatient");
        modelBuilder.Entity<Assistant>().ToTable("Assistant");


        }

        //public DbSet<MyClinic.Models.Treatment> Treatment { get; set; } = default!;
    }
}
