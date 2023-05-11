﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaNursingStation.DL.Entities
{
    public partial class eSyaEnterprise_SP : DbContext
    {
        public eSyaEnterprise_SP()
        {
        }

        public eSyaEnterprise_SP(DbContextOptions<eSyaEnterprise_SP> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(eSyaEnterprise._connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
        }

        public virtual DbSet<GHealthInPatient> GHealthInPatients { get; set; }
        public virtual DbSet<DrugCodes> DrugCodes { get; set; }
    }

    public class GHealthInPatient
    {
        public decimal HospitalNumber { get; set; }
        [Key]
        public decimal IPNumber { get; set; }
        public string PatientName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public DateTime EffectiveDateOfAdmission { get; set; }
        public string DischargedUnderDoctor { get; set; }
        public string DoctorName { get; set; }
        public string DischargedUnderSpecialty { get; set; }
        public string SpecialtyDesc { get; set; }
        public string WardType { get; set; }
        public string RoomType { get; set; }
        public string RoomTypeDesc { get; set; }
        public string BedNumber { get; set; }
    }

    public class DrugCodes
    {
        [Key]
        public decimal DrugCode { get; set; }
        
        public string DrugDescription { get; set; }
        public string DrugCategoryDesc { get; set; }
    }
}
