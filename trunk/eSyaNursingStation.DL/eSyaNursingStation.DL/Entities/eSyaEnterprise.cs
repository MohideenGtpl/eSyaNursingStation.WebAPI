﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eSyaNursingStation.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtIpcldg> GtIpcldg { get; set; }
        public virtual DbSet<GtIpcldi> GtIpcldi { get; set; }
        public virtual DbSet<GtIpclin> GtIpclin { get; set; }
        public virtual DbSet<GtIpcnvr> GtIpcnvr { get; set; }
        public virtual DbSet<GtIpnscd> GtIpnscd { get; set; }
        public virtual DbSet<GtIpnsch> GtIpnsch { get; set; }
        public virtual DbSet<GtIpotan> GtIpotan { get; set; }
        public virtual DbSet<GtOpclin> GtOpclin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);
            });

            modelBuilder.Entity<GtIpcldg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.DrugCode })
                    .HasName("PK_GT_IPCLDG_1");

                entity.ToTable("GT_IPCLDG");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DoctorName).HasMaxLength(250);

                entity.Property(e => e.Dosages).HasMaxLength(250);

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.LastMedicationDate).HasColumnType("datetime");

                entity.Property(e => e.MedicationEndDate).HasColumnType("datetime");

                entity.Property(e => e.MedicationStartDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Route).HasMaxLength(250);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtIpcldi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.DrugCode, e.MedicationGivenOn });

                entity.ToTable("GT_IPCLDI");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.MedicationGivenOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtIpclin>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.TransactionId, e.Cltype, e.ClcontrolId });

                entity.ToTable("GT_IPCLIN");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Cltype)
                    .HasColumnName("CLType")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ClcontrolId)
                    .HasColumnName("CLControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<GtIpcnvr>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.SerialNumber });

                entity.ToTable("GT_IPCNVR");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.ConsentType)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtIpnscd>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.NscontrolId });

                entity.ToTable("GT_IPNSCD");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.NscontrolId)
                    .HasColumnName("NSControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<GtIpnsch>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber });

                entity.ToTable("GT_IPNSCH");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.AssessmentStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtIpotan>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Ipnumber, e.TransactionId, e.Ottype, e.OtcontrolId });

                entity.ToTable("GT_IPOTAN");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Ipnumber).HasColumnName("IPNumber");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Ottype)
                    .HasColumnName("OTType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.OtcontrolId)
                    .HasColumnName("OTControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });

            modelBuilder.Entity<GtOpclin>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Uhid, e.Vnumber, e.TransactionId, e.Cltype, e.ClcontrolId });

                entity.ToTable("GT_OPCLIN");

                entity.Property(e => e.Uhid).HasColumnName("UHID");

                entity.Property(e => e.Vnumber).HasColumnName("VNumber");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Cltype)
                    .HasColumnName("CLType")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ClcontrolId)
                    .HasColumnName("CLControlID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.ValueType).HasMaxLength(20);
            });
        }
    }
}
