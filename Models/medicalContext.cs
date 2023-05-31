using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuroraAPI.Models
{
    public partial class medicalContext : DbContext
    {
             public medicalContext(DbContextOptions<medicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactPhone> ContactPhone { get; set; }
        public virtual DbSet<Doses1> Doses1 { get; set; }
        public virtual DbSet<Ec> Ec { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<UserDoseMedicine> UserDoseMedicine { get; set; }
        public virtual DbSet<UserPhone> UserPhone { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactPhone>(entity =>
            {
                entity.HasKey(e => e.Contact_Phone);

                entity.ToTable("contact_phone");

                entity.Property(e => e.Contact_Phone)
                    .HasColumnName("contact_phone")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Contact_Code).HasColumnName("contact_code");

                entity.HasOne(d => d.Contact_CodeNavigation)
                    .WithMany(p => p.ContactPhone)
                    .HasForeignKey(d => d.Contact_Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contact_phone_EC");
            });

            modelBuilder.Entity<Doses1>(entity =>
            {
                entity.HasKey(e => e.Dose_Code);

                entity.ToTable("Doses (1)");

                entity.Property(e => e.Dose_Code)
                    .HasColumnName("dose_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dose_Date)
                    .HasColumnName("dose_date")
                    .HasColumnType("date");

                entity.Property(e => e.Dose_Time).HasColumnName("dose_time");

                entity.Property(e => e.Time_Of_Abuse).HasColumnName("Time_of_abuse");
            });

            modelBuilder.Entity<Ec>(entity =>
            {
                entity.HasKey(e => e.Contact_Code);

                entity.ToTable("EC");

                entity.Property(e => e.Contact_Code)
                    .HasColumnName("contact_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.First_Name)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Last_Name)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.User_Id).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ec)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EC_users");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.Medicine_Code);

                entity.Property(e => e.Medicine_Code)
                    .HasColumnName("medicine_code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Medicine_Name)
                    .IsRequired()
                    .HasColumnName("Medicine_Name");

                entity.Property(e => e.No_Of_Pills_In_Tape).HasColumnName("no_of_pills_in_tape");

                entity.Property(e => e.No_Of_Tapes).HasColumnName("no_of_tapes");
            });

            modelBuilder.Entity<UserDoseMedicine>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.Medicine_Code);
                entity.HasKey(e => e.User_Id);
                entity.HasKey(e => e.Dose_Code);

                entity.ToTable("user_dose_medicine");

                entity.Property(e => e.Dose_Code).HasColumnName("dose_code");

                entity.Property(e => e.Medicine_Code).HasColumnName("medicine_code");

                entity.Property(e => e.Number_Of_Pills).HasColumnName("number_of_pills");

                entity.Property(e => e.User_Id).HasColumnName("User_ID");

                entity.HasOne(d => d.Dose_CodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Dose_Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_dose_medicin_dose");

                entity.HasOne(d => d.Medicine_CodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Medicine_Code)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_dose_medicinemedicine");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_dose_medicine_user");
            });

            modelBuilder.Entity<UserPhone>(entity =>
            {
                entity.HasKey(e => e.User_Phone);

                entity.ToTable("user_phone");

                entity.Property(e => e.User_Phone)
                    .HasColumnName("user_phone")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.User_Id).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPhone)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_phone_user");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.User_Id);

                entity.ToTable("users");

                entity.Property(e => e.User_Id)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.First_Name)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Last_Name)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.User_Email)
                    .HasColumnName("user_email")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}
