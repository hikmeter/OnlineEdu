using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Presentation.Dtos.RoleDtos;

namespace OnlineEdu.Presentation.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> _roleManager, IMapper _mapper) : IRoleService
    {
        public async Task CreateRoleAsync(CreateRoleDto dto)
        {
            var value = _mapper.Map<AppRole>(dto);
            await _roleManager.CreateAsync(value);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
        }

        public async Task<List<ResultRoleDto>> GetAllRolesAsync()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<ResultRoleDto>>(values);
        }

        public async Task<UpdateRoleDto> GetRoleByIdAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return new UpdateRoleDto
            {
                Id = value.Id,
                Name = value.Name
            };
        }

        public async Task UpdateRoleAsync(UpdateRoleDto dto)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == dto.Id);
            value.Name = dto.Name;
            await _roleManager.UpdateAsync(value);
        }
    }
}
