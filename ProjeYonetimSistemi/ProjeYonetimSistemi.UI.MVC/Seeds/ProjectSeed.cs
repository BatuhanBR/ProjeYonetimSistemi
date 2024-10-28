using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeYonetimSistemi.UI.MVC.Entity;
using System;

namespace ProjeYonetimSistemi.UI.MVC.Seeds
{
    public class ProjectSeed : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.HasData(
                new ProjectEntity
                {
                    Id = 1,
                    ProjectName = "Website Redesign",
                    TeamId = 1,  // Development Team'in TeamId'si
                    Description = "Revamping the entire website for better UX/UI.",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    TeamEntity = null // TeamEntity gezinme özelliğini null olarak bırakıyoruz
                },
                new ProjectEntity
                {
                    Id = 2,
                    ProjectName = "Mobile App Development",
                    TeamId = 1,  // Development Team'in TeamId'si
                    Description = "Creating a mobile application for our e-commerce platform.",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    TeamEntity = null // TeamEntity gezinme özelliğini null olarak bırakıyoruz
                },
                new ProjectEntity
                {
                    Id = 3,
                    ProjectName = "Social Media Marketing",
                    TeamId = 3,  // Marketing Team'in TeamId'si
                    Description = "Promoting the new product launch on social media channels.",
                    IsActive = false,
                    CreatedDate = DateTime.Now,
                    TeamEntity = null // TeamEntity gezinme özelliğini null olarak bırakıyoruz
                }
            );
        }
    }
}
