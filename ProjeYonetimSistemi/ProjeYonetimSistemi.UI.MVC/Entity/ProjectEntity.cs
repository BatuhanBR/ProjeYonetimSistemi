using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class ProjectEntity
    {

        public ProjectEntity()
        {
            TeamEntity = new TeamEntity();


        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Proje adı zorunludur.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Takım seçilmelidir.")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public TeamEntity? TeamEntity { get; set; }


    }
}
