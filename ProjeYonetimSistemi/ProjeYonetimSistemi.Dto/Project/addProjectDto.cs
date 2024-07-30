using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Dto.Project
{
    public class addProjectDto
    {
       
        [Required(ErrorMessage = "Proje adı zorunludur.")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Takım seçilmelidir.")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Açıklama alanı gereklidir.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
