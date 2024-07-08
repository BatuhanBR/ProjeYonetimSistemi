using System;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string? TaskName { get; set; } // Görev ismi
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; } // Eklenme tarihi
        public string? Status { get; set; } // Projenin ne durumda olduğu
        public int Progress { get; set; } // Progress Bar
    }
}
