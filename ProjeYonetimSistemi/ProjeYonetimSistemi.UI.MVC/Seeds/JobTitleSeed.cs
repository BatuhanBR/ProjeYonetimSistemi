using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjeYonetimSistemi.UI.MVC.Entity;

namespace ProjeYonetimSistemi.UI.MVC.Seeds
{
    public class JobTitleSeed : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(
                new JobTitle
                {
                    JobTitleId = 1,
                    JobName = "Software Engineer"
                },
                new JobTitle
                {
                    JobTitleId = 2,
                    JobName = "Project Manager"
                },
                new JobTitle
                {
                    JobTitleId = 3,
                    JobName = "UI/UX Designer"
                },
                new JobTitle
                {
                    JobTitleId = 4,
                    JobName = "QA Engineer"
                },
                new JobTitle
                {
                    JobTitleId = 5,
                    JobName = "DevOps Engineer"
                }
            );
        }
    }
}
