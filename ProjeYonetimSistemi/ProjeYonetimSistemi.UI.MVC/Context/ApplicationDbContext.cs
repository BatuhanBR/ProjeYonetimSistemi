// ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Entity;
using ProjeYonetimSistemi.UI.MVC.Models;

namespace ProjeYonetimSistemi.UI.MVC.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskEntity>()
                .HasOne(t => t.Project)
                .WithMany() // 
                .HasForeignKey(t => t.ProjectId);
        }

    }



}
