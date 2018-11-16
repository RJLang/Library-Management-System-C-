﻿// <auto-generated />
using System;
using Library_Management_System_C_;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library_Management_System_C_.Migrations
{
    [DbContext(typeof(LibraryModel))]
    partial class LibraryModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library_Management_System_C_.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50);

                    b.Property<int>("Fees");

                    b.Property<string>("Name");

                    b.HasKey("AccountNumber")
                        .HasName("PK_Account");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Library_Management_System_C_.Loans", b =>
                {
                    b.Property<int>("TransactinID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<bool>("Active");

                    b.Property<long>("ID");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<int>("TypeOfLoan");

                    b.HasKey("TransactinID")
                        .HasName("PK_Loans");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library_Management_System_C_.Media", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("AvailableCopies");

                    b.Property<int>("Category");

                    b.Property<DateTime>("OrginDate");

                    b.Property<string>("Title");

                    b.Property<int>("TotalCopies");

                    b.Property<int>("Type");

                    b.HasKey("ID")
                        .HasName("PK_Media");

                    b.ToTable("Media");
                });
#pragma warning restore 612, 618
        }
    }
}
