using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeYonetimSistemi.UI.MVC.Entity;

namespace ProjeYonetimSistemi.UI.MVC.Seeds
{
    public class TaskSeed : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasData(
                new TaskEntity
                {
                    Id = 1,
                    TaskName = "Design Homepage",
                    Description = "Creating the homepage design for the website.",
                    DueDate = DateTime.Now.AddDays(10),
                    CreatedDate = DateTime.Now,
                    Status = "In Progress",
                    Progress = 40,
                    ProjectId = 1 // Website Redesign
                },
                new TaskEntity
                {
                    Id = 2,
                    TaskName = "Backend Development",
                    Description = "Developing the backend services for the mobile app.",
                    DueDate = DateTime.Now.AddDays(15),
                    CreatedDate = DateTime.Now,
                    Status = "Not Started",
                    Progress = 0,
                    ProjectId = 2 // Mobile App Development
                },
                new TaskEntity
                {
                    Id = 3,
                    TaskName = "Content Creation",
                    Description = "Creating content for social media channels.",
                    DueDate = DateTime.Now.AddDays(5),
                    CreatedDate = DateTime.Now,
                    Status = "Completed",
                    Progress = 100,
                    ProjectId = 3 // Social Media Marketing
                }
            );
        }
    }
}
