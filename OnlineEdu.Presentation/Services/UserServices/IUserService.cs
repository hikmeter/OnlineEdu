using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.UserDtos;

namespace OnlineEdu.Presentation.Services.UserServices
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto dto);
        Task<LoginResultDto> LoginAsync(UserLoginDto dto);
        Task<bool> LogoutAsync();
        //Task<IdentityResult> CreateRoleAsync(UserRoleDto dto);
        Task<List<AssignRoleDto>> GetAssignRoleListAsync(int userId);
        Task<IdentityResult> AssignRoleAsync(int userId, List<AssignRoleDto> roleList);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<List<ResultUserDto>> GetAllTeachers();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<int> GetTeachersCount();
        Task<int> GetStudentsCount();
    }
}
