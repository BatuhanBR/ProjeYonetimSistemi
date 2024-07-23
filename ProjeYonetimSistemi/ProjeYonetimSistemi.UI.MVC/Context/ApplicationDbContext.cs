// ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Entity;
using ProjeYonetimSistemi.UI.MVC.Models;
using System.Reflection.Emit;

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
      

        public DbSet<TeamMemberEntity> TeamMembers { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<JobTitle> Jobs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskEntity>()
                .HasOne(t => t.Project)
                .WithMany() // 
                .HasForeignKey(t => t.ProjectId);

            builder.Entity<TeamEntity>()
               .HasKey(t => t.TeamId);

            builder.Entity<TeamMemberEntity>()
               .HasKey(t => t.TeamMemberId);

           



        }



    }
}
