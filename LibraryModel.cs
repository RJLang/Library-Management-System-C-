using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System_C_
{


    public class LibraryModel : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Media> Media { get; set; }

        public virtual DbSet<Loans> Loans { get; set; }

        public virtual DbSet<Account> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LibraryDB; Integrated Security = True; Connect Timeout = 30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///Account SQL Table
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                .HasName("PK_Account");

                entity.Property(e => e.AccountNumber)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailAddress)
                .HasMaxLength(50);

                entity.ToTable("Accounts");

            });

            //Media SQL Table
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.ID)
                .HasName("PK_Media");

                entity.Property(e => e.ID)
                .ValueGeneratedOnAdd();

                entity.ToTable("Media");

            });

            modelBuilder.Entity<Loans>(entity =>
            {
                entity.HasKey(e => e.TransactinID)
                .HasName("PK_Loans");

                entity.Property(e => e.TransactinID)
                .ValueGeneratedOnAdd();

                entity.ToTable("Loans");

            });

            //Placeholder for Loans - Foreign Key
            /*
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.ID)
                .HasName("PK_Account");

                entity.Property(e => e.ID)
                .ValueGeneratedOnAdd();

                entity.ToTable("Loans");

            });


            //Placeholder for Holds - Foreign Key
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(e => e.ID)
                .HasName("PK_Account");

                entity.Property(e => e.ID)
                .ValueGeneratedOnAdd();

                entity.ToTable("Holds");

            });
            */

        }

    }
}
