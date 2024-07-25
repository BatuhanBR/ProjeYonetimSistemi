using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjeYonetimSistemi.UI.MVC.ViewModels
{
    public class AddTeamMemberViewModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int JobTitleId { get; set; } 
        public IEnumerable<SelectListItem> JobTitles { get; set; } 
    }
}
