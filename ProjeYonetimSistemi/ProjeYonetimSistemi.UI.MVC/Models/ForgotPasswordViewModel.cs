using System.ComponentModel.DataAnnotations;

namespace ProjeYonetimSistemi.UI.MVC.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}