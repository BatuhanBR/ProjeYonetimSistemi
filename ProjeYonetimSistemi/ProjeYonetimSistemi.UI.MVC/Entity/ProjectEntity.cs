// Project.cs dosyası içinde
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Proje adı zorunludur.")]
        public string ProjectName { get; set; }
        public string TeamMembers { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
