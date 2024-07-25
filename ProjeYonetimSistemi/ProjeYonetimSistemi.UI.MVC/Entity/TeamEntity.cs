namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TeamEntity
    {
        public TeamEntity()
        {
            JobTitle = new List<JobTitle>();
        }
        
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public ICollection<TeamMemberEntity> TeamMembers { get; set; } = new List<TeamMemberEntity>();

        public List<JobTitle> JobTitle { get; set; }

    }
}
