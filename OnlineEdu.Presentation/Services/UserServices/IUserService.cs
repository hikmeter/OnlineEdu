using Microsoft.AspNetCore.Identity;
using OnlineEdu.Presentation.Dtos.UserDtos;

namespace OnlineEdu.Presentation.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto dto);
        Task<LoginResultDto> LoginAsync(UserLoginDto dto);
        Task<bool> LogoutAsync();
        Task<IdentityResult> CreateRoleAsync(UserRoleDto dto);
        Task<IdentityResult> AssignRoleAsync(AssignRoleDto dto);
    }
}
