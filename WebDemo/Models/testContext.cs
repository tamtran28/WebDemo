using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebDemo.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allowance> Allowances { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentPosition> DepartmentPositions { get; set; }
        public virtual DbSet<DetailSalary> DetailSalaries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Overtime> Overtimes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Work> Works { get; set; }
        public virtual DbSet<WorkingDay> WorkingDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HCM-IED-TAMTNT\\SQLEXPRESS;Database=test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.Property(e => e.AllowanceId)
                    .ValueGeneratedNever()
                    .HasColumnName("AllowanceID");

                entity.Property(e => e.OtherAllowance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PhoneAllowance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PositionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Allowance__Posit__412EB0B6");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID")
                    .IsFixedLength(true);

                entity.Property(e => e.DepartmentManagerId).HasColumnName("DepartmentManagerID");

                entity.Property(e => e.NameDepartment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartmentPosition>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.PositionId })
                    .HasName("PK__Departme__340C2268FE818A36");

                entity.ToTable("DepartmentPosition");

                entity.Property(e => e.DepartmentId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID")
                    .IsFixedLength(true);

                entity.Property(e => e.PositionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentPositions)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__440B1D61");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.DepartmentPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Posit__44FF419A");
            });

            modelBuilder.Entity<DetailSalary>(entity =>
            {
                entity.ToTable("DetailSalary");

                entity.Property(e => e.DetailSalaryId).HasColumnName("DetailSalaryID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.HealthInsurance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PersonalIncomeTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.SocialInsurance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalSalary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.DetailSalaries)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetailSal__Salar__47DBAE45");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.DateStartWork).HasColumnType("date");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DepartmentID")
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.PositionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Positi__34C8D9D1");
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.ToTable("Overtime");

                entity.Property(e => e.OvertimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("OvertimeID");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.OvertimeDate).HasColumnType("date");

                entity.Property(e => e.OvertimeHours).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.OvertimeRate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Overtimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Overtime__Employ__3E52440B");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.Property(e => e.BaseSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NamePosition)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.DateRecieved).HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__Employee__38996AB5");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.WorkingDayId })
                    .HasName("PK__Work__FCA402BE8B85409A");

                entity.ToTable("Work");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.WorkingDayId).HasColumnName("WorkingDayID");

                entity.Property(e => e.TimeEnd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStar)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Work__EmployeeID__4AB81AF0");

                entity.HasOne(d => d.WorkingDay)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.WorkingDayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Work__WorkingDay__4BAC3F29");
            });

            modelBuilder.Entity<WorkingDay>(entity =>
            {
                entity.ToTable("WorkingDay");

                entity.Property(e => e.WorkingDayId)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkingDayID");

                entity.Property(e => e.DateWork).HasColumnType("date");

                entity.Property(e => e.Describe)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
