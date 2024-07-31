using Application;
using Application.Constants;
using Application.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.SqlServerDb.Repositories;
internal class UserRepository(UserManager<ApplicationUser> userManager, IOptions<HelperJWT> helperJWT) : IUserService {

    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly HelperJWT _helperJWT = helperJWT.Value;

    public async Task<ApplicationResponse<ApplicationUser>> LoginAsync(ApplicationUser user) {

        var applicationResponse = new ApplicationResponse<ApplicationUser>();

        try {

            var userFind = await _userManager.FindByEmailAsync(user.Email);

            if (userFind is null || !await _userManager.CheckPasswordAsync(userFind, user.Password)) {

                applicationResponse.Message = CustomConstants.User.Incorrect;
                return applicationResponse;
            }

            var jwtToken = await CreateJwtToken(userFind);
            string stringToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            applicationResponse.Data = new ApplicationUser { SecurityStamp = stringToken };
        }
        catch (Exception e) {

            Console.WriteLine(e.Message);
        }

        applicationResponse.Success = true;
        return applicationResponse;
    }

    public async Task<ApplicationResponse<ApplicationUser>> RegisterAsync(ApplicationUser user) {

        var applicationResponse = new ApplicationResponse<ApplicationUser>();

        try {

            if (await _userManager.FindByEmailAsync(user.Email) is not null) {
                applicationResponse.Message = CustomConstants.User.EmailIsTaken;
                return applicationResponse;
            }

            var result = await _userManager.CreateAsync(user, user.Password);

            if (!result.Succeeded) {
                var errors = string.Empty;

                foreach (var error in result.Errors) {
                    errors += $"{error.Description},";
                }

                applicationResponse.Message = errors;
                return applicationResponse;
            }

            var jwtToken = await CreateJwtToken(user);
            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            applicationResponse.Data = new ApplicationUser { SecurityStamp = stringToken };

        }
        catch (Exception e) {
            Console.WriteLine(e.Message);

        }

        applicationResponse.Success = true;
        return applicationResponse;
    }

    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user) {
        try {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!)
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_helperJWT.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _helperJWT.Issuer,
                audience: _helperJWT.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_helperJWT.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            return null;
        }
    }

}
