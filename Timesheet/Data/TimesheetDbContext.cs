using Microsoft.EntityFrameworkCore;
using Timesheet.Models;
using System.Security.Cryptography;
using System.Text;
using Timesheet.Enum;

namespace Timesheet.Data
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HR> HRs { get; set; }
          
        public DbSet<TimesheetDb> Timesheets { get; set; }


        public DbSet<Admins> Admins { get; set; }

        public DbSet<LeaveDb> Leaves { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("Unassigned");

            modelBuilder.Entity<Employee>()
                  .HasOne(e => e.User)
                  .WithOne()
                  .HasForeignKey<Employee>(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // HR ↔ User Relationship
            modelBuilder.Entity<HR>()
                .HasOne(h => h.User)
                .WithOne()
                .HasForeignKey<HR>(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Admin ↔ User Relationship
            modelBuilder.Entity<Admins>().HasIndex(a => a.UserId).IsUnique();

            // Timesheet ↔ Employee Relationship
            modelBuilder.Entity<TimesheetDb>()
    .HasOne(t => t.Employee)  // One Timesheet belongs to one Employee
    .WithMany(e => e.Timesheets)  // One Employee can have multiple Timesheets
    .HasForeignKey(t => t.EmployeeId)  // FK is EmployeeId
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TimesheetDb>()
    .Property(t => t.Status)
    .HasConversion<string>()
    .HasDefaultValue(TimesheetStatus.Pending);


            modelBuilder.Entity<LeaveDb>()
     .HasOne(l => l.Employee)
     .WithMany(e => e.LeaveRequests)
     .HasForeignKey(l => l.EmployeeId)
     .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<LeaveDb>()
                .Property(l => l.Status)
                .HasConversion<string>()  // Convert enum to string
                .HasDefaultValue(LeaveStatus.Pending);

            modelBuilder.Entity<LeaveDb>()
    .Property(l => l.StartDate)
    .HasConversion(
        v => v.ToString(), // Convert DateOnly to string for DB storage
        v => DateOnly.Parse(v) // Convert back to DateOnly when reading from DB
    );

            modelBuilder.Entity<LeaveDb>()
                .Property(l => l.EndDate)
                .HasConversion(
                    v => v.ToString(),
                    v => DateOnly.Parse(v)
                );

            // Add index to EmployeeId in LeaveDb for performance
            modelBuilder.Entity<LeaveDb>()
                .HasIndex(l => l.EmployeeId);

            // Timesheet Properties
            modelBuilder.Entity<TimesheetDb>().HasKey(t => t.TimesheetId);
            modelBuilder.Entity<TimesheetDb>().Property(t => t.TimesheetId).ValueGeneratedOnAdd();
            modelBuilder.Entity<TimesheetDb>().Property(t => t.EmployeeId).IsRequired();
            modelBuilder.Entity<TimesheetDb>().Property(t => t.ProjectName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<TimesheetDb>().Property(t => t.HoursWorked).IsRequired();
            modelBuilder.Entity<TimesheetDb>().Property(t => t.Status).HasDefaultValue(TimesheetStatus.Pending);
            modelBuilder.Entity<TimesheetDb>().Property(t => t.Date).IsRequired();
            modelBuilder.Entity<TimesheetDb>().Property(t => t.Description).HasMaxLength(500);




            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasColumnType("varbinary(max)");

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordSalt)
                .HasColumnType("varbinary(max)");

            modelBuilder.Entity<TimesheetDb>()
               .HasKey(t => t.TimesheetId);
            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.TimesheetId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.EmployeeId)
                .IsRequired();

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.ProjectName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.HoursWorked)
                .IsRequired();

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.Status)
                .HasDefaultValue(TimesheetStatus.Pending); // Ensure TimesheetStatus is an enum

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.Date)
                .IsRequired();

            modelBuilder.Entity<TimesheetDb>()
                .Property(t => t.Description)
                .HasMaxLength(500);

            using var hmac = new HMACSHA512();
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Admin@123"));
            var passwordSalt = hmac.Key;

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                  
                    FullName = "Admin",
                    Email = "admin@timesheet.com",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = "Admin",
                    Department = "Admin",
                    DateOfBirth = DateOnly.Parse("2002-06-06"),
                    JoiningDate= DateOnly.Parse("2025-01-01"),
                    Designation="Admin",

                    PhoneNumber = "9876543456",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
