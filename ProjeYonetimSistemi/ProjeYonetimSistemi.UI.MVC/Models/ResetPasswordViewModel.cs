using System.ComponentModel.DataAnnotations;

public class ResetPasswordViewModel
{
    [Required]
    public string? UserId { get; set; }

    [Required]
    public string? Token { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string? ConfirmPassword { get; set; }
}
