using Microsoft.EntityFrameworkCore;
using Timesheet.Models;
using System.Security.Cryptography;
using System.Text;

namespace Timesheet.Data
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext(DbContextOptions<TimesheetDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<HR> HRs { get; set; }

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

            
            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .HasColumnType("varbinary(max)");

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordSalt)
                .HasColumnType("varbinary(max)");
            
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

                    PhoneNumber = "9876543456",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
