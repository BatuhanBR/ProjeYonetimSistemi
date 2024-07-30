using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TeamEntity
    {
        public TeamEntity()
        {
            //TeamMembers = new List<TeamMemberEntity>();
            //JobTitles = new List<JobTitle>();
    
        }
        [Key]
        public int TeamId { get; set; }
      
        public string TeamName { get; set; }
 

  
    }
}
