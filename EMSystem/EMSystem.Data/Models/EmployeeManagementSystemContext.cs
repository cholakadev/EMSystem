using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EMSystem.Data.Models
{
    public partial class EmployeeManagementSystemContext : DbContext
    {
        public EmployeeManagementSystemContext()
        {
        }

        public EmployeeManagementSystemContext(DbContextOptions<EmployeeManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeContact> EmployeeContacts { get; set; }
        public virtual DbSet<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GIAS8II\\SQLEXPRESS;Database=EmployeeManagementSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.MiddleName).HasMaxLength(64);

                entity.Property(e => e.Salary).HasColumnType("decimal(7, 2)");

                entity.Property(e => e.Team).HasMaxLength(128);
            });

            modelBuilder.Entity<EmployeeContact>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__Employee__5C66259B209CF036");

                entity.ToTable("EmployeeContact");

                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.MobileNumber).HasMaxLength(64);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeContacts)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeC__Emplo__38996AB5");
            });

            modelBuilder.Entity<EmployeeSupervisor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EmployeeSupervisor");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Emplo__3D5E1FD2");

                entity.HasOne(d => d.Supervisor)
                    .WithMany()
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Super__3E52440B");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.ToTable("Supervisor");

                entity.Property(e => e.SupervisorId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Supervisors)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Superviso__Emplo__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
