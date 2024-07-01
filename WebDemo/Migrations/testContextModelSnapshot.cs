﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebDemo.Models;

namespace WebDemo.Migrations
{
    [DbContext(typeof(testContext))]
    partial class testContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDemo.Models.Allowance", b =>
                {
                    b.Property<int>("AllowanceId")
                        .HasColumnType("int")
                        .HasColumnName("AllowanceID");

                    b.Property<decimal>("OtherAllowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PhoneAllowance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PositionID");

                    b.HasKey("AllowanceId");

                    b.HasIndex("PositionId");

                    b.ToTable("Allowances");
                });

            modelBuilder.Entity("WebDemo.Models.Department", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("DepartmentID")
                        .IsFixedLength(true);

                    b.Property<int>("DepartmentManagerId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentManagerID");

                    b.Property<string>("NameDepartment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebDemo.Models.DepartmentPosition", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("DepartmentID")
                        .IsFixedLength(true);

                    b.Property<string>("PositionId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PositionID");

                    b.HasKey("DepartmentId", "PositionId")
                        .HasName("PK__Departme__340C2268FE818A36");

                    b.HasIndex("PositionId");

                    b.ToTable("DepartmentPosition");
                });

            modelBuilder.Entity("WebDemo.Models.DetailSalary", b =>
                {
                    b.Property<int>("DetailSalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DetailSalaryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("date");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("EmployeeID");

                    b.Property<decimal>("HealthInsurance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PersonalIncomeTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SalaryId")
                        .HasColumnType("int")
                        .HasColumnName("SalaryID");

                    b.Property<decimal>("SocialInsurance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetailSalaryId");

                    b.HasIndex("SalaryId");

                    b.ToTable("DetailSalary");
                });

            modelBuilder.Entity("WebDemo.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateStartWork")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .HasColumnName("DepartmentID")
                        .IsFixedLength(true);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PositionID");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WebDemo.Models.Overtime", b =>
                {
                    b.Property<int>("OvertimeId")
                        .HasColumnType("int")
                        .HasColumnName("OvertimeID");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("OvertimeDate")
                        .HasColumnType("date");

                    b.Property<decimal>("OvertimeHours")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("OvertimeRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OvertimeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Overtime");
                });

            modelBuilder.Entity("WebDemo.Models.Position", b =>
                {
                    b.Property<string>("PositionId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PositionID");

                    b.Property<decimal>("BaseSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NamePosition")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("PositionId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("WebDemo.Models.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalaryID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateRecieved")
                        .HasColumnType("date");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("TotalWorkingDay")
                        .HasColumnType("int");

                    b.HasKey("SalaryId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Salary");
                });

            modelBuilder.Entity("WebDemo.Models.Work", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("EmployeeID");

                    b.Property<int>("WorkingDayId")
                        .HasColumnType("int")
                        .HasColumnName("WorkingDayID");

                    b.Property<int?>("OverTime")
                        .HasColumnType("int");

                    b.Property<string>("TimeEnd")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TimeStar")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("TotalHourWorking")
                        .HasColumnType("int");

                    b.Property<int?>("TotalWorkingDay")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "WorkingDayId")
                        .HasName("PK__Work__FCA402BE8B85409A");

                    b.HasIndex("WorkingDayId");

                    b.ToTable("Work");
                });

            modelBuilder.Entity("WebDemo.Models.WorkingDay", b =>
                {
                    b.Property<int>("WorkingDayId")
                        .HasColumnType("int")
                        .HasColumnName("WorkingDayID");

                    b.Property<DateTime>("DateWork")
                        .HasColumnType("date");

                    b.Property<string>("Describe")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("WorkingDayId");

                    b.ToTable("WorkingDay");
                });

            modelBuilder.Entity("WebDemo.Models.Allowance", b =>
                {
                    b.HasOne("WebDemo.Models.Position", "Position")
                        .WithMany("Allowances")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Allowance__Posit__412EB0B6")
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebDemo.Models.DepartmentPosition", b =>
                {
                    b.HasOne("WebDemo.Models.Department", "Department")
                        .WithMany("DepartmentPositions")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Departmen__Depar__440B1D61")
                        .IsRequired();

                    b.HasOne("WebDemo.Models.Position", "Position")
                        .WithMany("DepartmentPositions")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Departmen__Posit__44FF419A")
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebDemo.Models.DetailSalary", b =>
                {
                    b.HasOne("WebDemo.Models.Salary", "Salary")
                        .WithMany("DetailSalaries")
                        .HasForeignKey("SalaryId")
                        .HasConstraintName("FK__DetailSal__Salar__47DBAE45")
                        .IsRequired();

                    b.Navigation("Salary");
                });

            modelBuilder.Entity("WebDemo.Models.Employee", b =>
                {
                    b.HasOne("WebDemo.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Employee__Positi__34C8D9D1")
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebDemo.Models.Overtime", b =>
                {
                    b.HasOne("WebDemo.Models.Employee", "Employee")
                        .WithMany("Overtimes")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Overtime__Employ__3E52440B")
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebDemo.Models.Salary", b =>
                {
                    b.HasOne("WebDemo.Models.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Salary__Employee__38996AB5")
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebDemo.Models.Work", b =>
                {
                    b.HasOne("WebDemo.Models.Employee", "Employee")
                        .WithMany("Works")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Work__EmployeeID__4AB81AF0")
                        .IsRequired();

                    b.HasOne("WebDemo.Models.WorkingDay", "WorkingDay")
                        .WithMany("Works")
                        .HasForeignKey("WorkingDayId")
                        .HasConstraintName("FK__Work__WorkingDay__4BAC3F29")
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("WorkingDay");
                });

            modelBuilder.Entity("WebDemo.Models.Department", b =>
                {
                    b.Navigation("DepartmentPositions");
                });

            modelBuilder.Entity("WebDemo.Models.Employee", b =>
                {
                    b.Navigation("Overtimes");

                    b.Navigation("Salaries");

                    b.Navigation("Works");
                });

            modelBuilder.Entity("WebDemo.Models.Position", b =>
                {
                    b.Navigation("Allowances");

                    b.Navigation("DepartmentPositions");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebDemo.Models.Salary", b =>
                {
                    b.Navigation("DetailSalaries");
                });

            modelBuilder.Entity("WebDemo.Models.WorkingDay", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
