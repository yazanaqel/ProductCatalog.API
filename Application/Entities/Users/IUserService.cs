namespace Application.Entities.Users;
public interface IUserService {
    Task<ApplicationResponse<ApplicationUser>> LoginAsync(ApplicationUser user);
    Task<ApplicationResponse<ApplicationUser>> RegisterAsync(ApplicationUser user);
}
