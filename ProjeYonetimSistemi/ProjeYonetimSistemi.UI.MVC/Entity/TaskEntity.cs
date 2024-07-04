using System;
using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Entity
{
    public class TaskEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}
