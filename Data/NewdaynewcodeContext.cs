using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newdaynewcode.Model;
using System;

namespace Newdaynewcode.Data
{
    public class NewdaynewcodeContext : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GFUVFUP;Initial Catalog=T754323_New_day_new_code;Persist Security Info=True;user id=pankazz;password=123456;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<UserRole>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Books>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasOne(a => a.Tenant).WithMany(b => b.Users).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.Tenant).WithMany(b => b.Roles).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserRole>().HasOne(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RolId);
            modelBuilder.Entity<UserRole>().HasOne(a => a.User).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserRole>().HasOne(a => a.Tenant).WithMany(b => b.UserRoles).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserRole>().HasOne(a => a.CreatedByUser).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserRole>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Author>().HasOne(a => a.Tenant).WithMany(b => b.Authors).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Author>().HasOne(a => a.CreatedByUser).WithMany(b => b.Authors).HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Author>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Books>().HasOne(a => a.Author).WithMany(b => b.Bookss).HasForeignKey(c => c.AuthorId);
            modelBuilder.Entity<Books>().HasOne(a => a.Tenant).WithMany(b => b.Bookss).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Books>().HasOne(a => a.CreatedByUser).WithMany(b => b.Bookss).HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Books>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
        }

        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}