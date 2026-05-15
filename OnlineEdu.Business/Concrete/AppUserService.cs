using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.AppUserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class AppUserService(IAppUserRepository _repository, UserManager<AppUser> _manager, IMapper _mapper) : IAppUserService
    {
        public async Task<List<ResultAppUserDto>> GetAllTeachers()
        {
            var values = await _repository.GetUsersWithSocials();
            var teachers = values.Where(y => _manager.IsInRoleAsync(y, "Teacher").Result).ToList();
            return _mapper.Map<List<ResultAppUserDto>>(teachers);
        }
    }
}
