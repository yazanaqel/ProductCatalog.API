using Microsoft.AspNetCore.Identity;

namespace Application.Entities.Users;
public class ApplicationUser : IdentityUser {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
