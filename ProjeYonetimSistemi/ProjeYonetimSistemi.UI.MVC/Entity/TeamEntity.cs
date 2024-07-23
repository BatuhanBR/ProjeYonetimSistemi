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

        public List<JobTitle> JobTitle { get; set; }

    }
}
