using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Users;
public class UserLoginDto
{
    [Required, EmailAddress(ErrorMessage = "Email Address is required")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
