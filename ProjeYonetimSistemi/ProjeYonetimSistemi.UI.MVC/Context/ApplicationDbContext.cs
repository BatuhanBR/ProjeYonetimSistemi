using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Entity;
using ProjeYonetimSistemi.UI.MVC.Models;

namespace ProjeYonetimSistemi.UI.MVC.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

    }
}
