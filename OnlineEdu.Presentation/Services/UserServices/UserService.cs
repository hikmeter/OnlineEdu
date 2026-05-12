using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.UserDtos;

namespace OnlineEdu.Presentation.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager) : IUserService
    {
        public Task<IdentityResult> AssignRoleAsync(AssignRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateRoleAsync(UserRoleDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return IdentityResult.Failed(
                    new IdentityError
                    {
                        Code = "PasswordMismatch",
                        Description = "Şifreler eşleşmiyor."
                    });
            }
            var user = new AppUser
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                UserName = dto.Username
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            return result;
        }

        public async Task<LoginResultDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user is null)
            {
                return new LoginResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "Kullanıcı bulunamadı!"
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (!result.Succeeded)
            {
                return new LoginResultDto
                {
                    Succeeded = false,
                    ErrorMessage = "Kullanıcı adı ya da şifre hatalı!"
                };
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return new LoginResultDto
                {
                    Succeeded = true,
                    Role = "Admin"
                };
            }

            if (await _userManager.IsInRoleAsync(user, "Teacher"))
            {
                return new LoginResultDto
                {
                    Succeeded = true,
                    Role = "Teacher"
                };
            }

            return new LoginResultDto
            {
                Succeeded = true,
                Role = "Student"
            };
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
