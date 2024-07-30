namespace ProjeYonetimSistemi.UI.MVC.Dto.Project

{
    public class ProjectDto
    {

        public string ProjectName { get; set; }

        public string TeamName { get; set; }




        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
