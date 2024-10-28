using Microsoft.EntityFrameworkCore;
using ProjeYonetimSistemi.UI.MVC.Entity;

namespace ProjeYonetimSistemi.UI.MVC.Seeds
{
    public class TeamSeed : IEntityTypeConfiguration<TeamEntity>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasData(
                new TeamEntity
                {
                    TeamId = 1,
                    TeamName = "Development"
                },
                new TeamEntity
                {
                    TeamId = 2,
                    TeamName = "Design"
                },
                new TeamEntity
                {
                    TeamId = 3,
                    TeamName = "Marketing"
                },
                new TeamEntity
                {
                    TeamId = 4,
                    TeamName = "Tosba Takımı"
                },
                 new TeamEntity
                 {
                     TeamId = 5,
                     TeamName = "Yıldırım Takımı"
                 }
            );
        }
    }
}
