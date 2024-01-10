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

        public DbSet<Treatment> Treatments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Treatment>().ToTable("Treatment");
        }

        public DbSet<MyClinic.Models.Treatment> Treatment { get; set; } = default!;
    }
}
