﻿// <auto-generated />
using System;
using Heliondata.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Heliondata.Migrations
{
    [DbContext(typeof(HelionDBContext))]
    partial class HelionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Heliondata.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CUI")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CUI = 123456789,
                            Name = "Company A"
                        },
                        new
                        {
                            ID = 2,
                            CUI = 987654321,
                            Name = "Company B"
                        });
                });

            modelBuilder.Entity("Heliondata.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "Sam",
                            LastName = "Wilson",
                            Position = "Analyst"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "Lucy",
                            LastName = "Hart",
                            Position = "Manager"
                        });
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.EmployeeProcess", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProcessId");

                    b.ToTable("EmployeeProcess");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EmployeeId = 1,
                            ProcessId = 1
                        },
                        new
                        {
                            ID = 2,
                            EmployeeId = 2,
                            ProcessId = 2
                        });
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.ProcessService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProcessId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProcessService");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ProcessId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            ID = 2,
                            ProcessId = 2,
                            ServiceId = 2
                        });
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.ProcessWorkplace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int>("WorkplaceId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProcessId");

                    b.HasIndex("WorkplaceId");

                    b.ToTable("ProcessWorkplace");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ProcessId = 1,
                            WorkplaceId = 1
                        },
                        new
                        {
                            ID = 2,
                            ProcessId = 2,
                            WorkplaceId = 2
                        });
                });

            modelBuilder.Entity("Heliondata.Models.Process", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ESignature")
                        .HasColumnType("longblob");

                    b.Property<string>("GPSLocation")
                        .HasColumnType("longtext");

                    b.Property<int>("RepresentativeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RepresentativeId");

                    b.ToTable("Processes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CompanyId = 1,
                            ESignature = new byte[] { 83, 105, 103, 110, 97, 116, 117, 114, 101, 49, 68, 97, 116, 97 },
                            GPSLocation = "47.0428222 21.9190659",
                            RepresentativeId = 1,
                            SignDate = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = 2,
                            CompanyId = 2,
                            ESignature = new byte[] { 83, 105, 103, 110, 97, 116, 117, 114, 101, 49, 68, 97, 116, 97 },
                            GPSLocation = "27.1433222 32.9123659",
                            RepresentativeId = 2,
                            SignDate = new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Heliondata.Models.Representative", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Representatives");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CompanyID = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Position = "Manager"
                        },
                        new
                        {
                            ID = 2,
                            CompanyID = 1,
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            Position = "Supervisor"
                        },
                        new
                        {
                            ID = 3,
                            CompanyID = 2,
                            Email = "bob.johnson@example.com",
                            FirstName = "Bob",
                            LastName = "Johnson",
                            Position = "Director"
                        },
                        new
                        {
                            ID = 4,
                            CompanyID = 2,
                            Email = "emma.brown@example.com",
                            FirstName = "Emma",
                            LastName = "Brown",
                            Position = "Coordinator"
                        });
                });

            modelBuilder.Entity("Heliondata.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "CCTV"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Security"
                        });
                });

            modelBuilder.Entity("Heliondata.Models.Workplace", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Zone")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Workplaces");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "123 5th Ave",
                            City = "New York",
                            Name = "Headquarters",
                            Zone = "Downtown"
                        },
                        new
                        {
                            ID = 2,
                            Address = "456 7th Ave",
                            City = "New York",
                            Name = "Branch Office",
                            Zone = "Uptown"
                        });
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.EmployeeProcess", b =>
                {
                    b.HasOne("Heliondata.Models.Employee", "Employee")
                        .WithMany("EmployeeProcesses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heliondata.Models.Process", "Process")
                        .WithMany("EmployeeProcesses")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.ProcessService", b =>
                {
                    b.HasOne("Heliondata.Models.Process", "Process")
                        .WithMany("ProcessServices")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heliondata.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Heliondata.Models.JoinModels.ProcessWorkplace", b =>
                {
                    b.HasOne("Heliondata.Models.Process", "Process")
                        .WithMany("ProcessWorkplaces")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heliondata.Models.Workplace", "Workplace")
                        .WithMany()
                        .HasForeignKey("WorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("Heliondata.Models.Process", b =>
                {
                    b.HasOne("Heliondata.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Heliondata.Models.Representative", "Representative")
                        .WithMany("Processes")
                        .HasForeignKey("RepresentativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Representative");
                });

            modelBuilder.Entity("Heliondata.Models.Representative", b =>
                {
                    b.HasOne("Heliondata.Models.Company", "Company")
                        .WithMany("Representatives")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Heliondata.Models.Company", b =>
                {
                    b.Navigation("Representatives");
                });

            modelBuilder.Entity("Heliondata.Models.Employee", b =>
                {
                    b.Navigation("EmployeeProcesses");
                });

            modelBuilder.Entity("Heliondata.Models.Process", b =>
                {
                    b.Navigation("EmployeeProcesses");

                    b.Navigation("ProcessServices");

                    b.Navigation("ProcessWorkplaces");
                });

            modelBuilder.Entity("Heliondata.Models.Representative", b =>
                {
                    b.Navigation("Processes");
                });
#pragma warning restore 612, 618
        }
    }
}
