using ProjeYonetimSistemi.UI.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TaskEntity
    {

        public TaskEntity()
        {
            Project=new ProjectEntity();
        }
        public int Id { get; set; }
        public string? TaskName { get; set; } // Görev ismi
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Status { get; set; } // Projenin ne durumda olduğu
        public int Progress { get; set; } // Progress Bar



        [Required]
        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; }

       
    }
}
