// Project.cs dosyası içinde
namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string TeamMembers { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
