using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.UserDtos;

namespace OnlineEdu.Presentation.Services.UserServices
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<AppRole> _roleManager, IMapper _mapper) : IUserService
    {
        public async Task<IdentityResult> AssignRoleAsync(int userId, List<AssignRoleDto> roleList)
        {
            var user = await GetUserByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in roleList)
            {
                if (role.IsRoleExists)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }
            return IdentityResult.Success;
        }


        //public Task<IdentityResult> CreateRoleAsync(UserRoleDto dto)
        //{
        //    throw new NotImplementedException();
        //}

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
            await _userManager.AddToRoleAsync(user, "Student");
            return result;
        }

        public async Task<List<ResultUserDto>> GetAllTeachers()
        {
            var values = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var teachers = values.Where(y => _userManager.IsInRoleAsync(y, "Teacher").Result).ToList();
            return _mapper.Map<List<ResultUserDto>>(values);
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<List<AssignRoleDto>> GetAssignRoleListAsync(int userId)
        {
            var user = await GetUserByIdAsync(userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<AssignRoleDto> result = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                result.Add(new AssignRoleDto
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsRoleExists = userRoles.Contains(role.Name)
                });
            }
            return result;
        }

        public async Task<int> GetStudentsCount()
        {
            var values = await _userManager.GetUsersInRoleAsync("Student");
            return values.Count;
        }

        public async Task<int> GetTeachersCount()
        {
            var values = await _userManager.GetUsersInRoleAsync("Teacher");
            return values.Count;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
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
