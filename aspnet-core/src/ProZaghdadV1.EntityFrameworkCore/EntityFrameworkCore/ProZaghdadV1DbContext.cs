using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProZaghdadV1.Authorization.Roles;
using ProZaghdadV1.Authorization.Users;
using ProZaghdadV1.MultiTenancy;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.EntityFrameworkCore
{
    public class ProZaghdadV1DbContext : AbpZeroDbContext<Tenant, Role, User, ProZaghdadV1DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ProZaghdadV1DbContext(DbContextOptions<ProZaghdadV1DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Abp.Localization.ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100);

            modelBuilder.Entity<College>()
                .HasMany(e => e.Students)
                .WithOne(e => e.College)
                .HasForeignKey("CollegeId")
                .OnDelete(DeleteBehavior.Restrict);

        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
    }
}
