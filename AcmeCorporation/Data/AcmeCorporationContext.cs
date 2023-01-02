using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AcmeCorporation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorporationNewDatabase
{
    public class AcmeCorporationContext : DbContext
    {
        public AcmeCorporationContext (DbContextOptions<AcmeCorporationContext> options)
            : base(options)
        {
        }

        public DbSet<AcmeCorporation.Models.Submission> Submission { get; set; } = default!;

        public DbSet<AcmeCorporation.Models.SerialNumber> SerialNumber { get; set; } = default!;

       
       
       /* protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Submission>()
                .HasOne(s => s.SerialNumber)
                .WithMany(n => n.Submissions)
                .HasForeignKey(s => s.SerialNumberProductSerialNumber)
                .HasPrincipalKey(n => n.ProductSerialNumber)
                .IsRequired();
        } */
        



    }
}

    
