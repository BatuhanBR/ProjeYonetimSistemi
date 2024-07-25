namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TeamMemberEntity
    {
        public int TeamMemberId { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }

        public JobTitle JobTitle { get; set; }
        public int JobTitleId { get; set; }
        public int TeamId { get; set; } 
        public TeamEntity Team { get; set; } 


    }
}
