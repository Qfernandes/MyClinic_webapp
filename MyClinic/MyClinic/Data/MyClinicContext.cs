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
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Patient>().ToTable("Patient");
        modelBuilder.Entity<Treatment>().ToTable("Treatment");
        modelBuilder.Entity<Treatmentpatient>().ToTable("Treatmentpatient");
        modelBuilder.Entity<Assistant>().ToTable("Assistant");
        modelBuilder.Entity<Payment>().ToTable("Payment");
        modelBuilder.Entity<Schedule>().ToTable("Schedule");


        }

        //public DbSet<MyClinic.Models.Treatment> Treatment { get; set; } = default!;
    }
}
