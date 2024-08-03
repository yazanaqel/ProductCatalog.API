using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Users;

public class UserRegisterDto
{

    [Required, MaxLength(15)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(15)]
    public string? LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, PasswordPropertyText]
    public string Password { get; set; } = string.Empty;

    [Required, PasswordPropertyText, Compare(nameof(Password))]
    public string PasswordConfirm { get; set; } = string.Empty;

}