using OnlineEdu.Presentation.Dtos.RoleDtos;

namespace OnlineEdu.Presentation.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDto>> GetAllRolesAsync();
        Task<UpdateRoleDto> GetRoleByIdAsync(int id);
        Task CreateRoleAsync(CreateRoleDto dto);
        Task UpdateRoleAsync(UpdateRoleDto dto);
        Task DeleteRoleAsync(int id);
    }
}
