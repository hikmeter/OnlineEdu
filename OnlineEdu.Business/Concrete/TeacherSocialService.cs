using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class TeacherSocialService(IRepository<TeacherSocial> _repository, ITeacherSocialRepository _socialRepository, IMapper _mapper) :
ITeacherSocialService
    {
        public async Task CreateTeacherSocial(CreateTeacherSocialDto dto)
        {
            var result = _mapper.Map<TeacherSocial>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteTeacherSocial(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetTeacherSocialByIdDto> GetTeacherSocialById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetTeacherSocialByIdDto>(value);
        }

        public async Task<List<ResultTeacherSocialDto>> GetTeacherSocialList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultTeacherSocialDto>>(values);
        }

        public async Task<List<GetTeacherSocialsWithSocialMediasDto>> GetTeacherSocialsByTeacherId(int id)
        {
            var values = await _socialRepository.GetTeacherSocialsByIdAsync(id);
            return _mapper.Map<List<GetTeacherSocialsWithSocialMediasDto>>(values);
        }

        public async Task UpdateTeacherSocial(UpdateTeacherSocialDto dto)
        {
            var value = _mapper.Map<TeacherSocial>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
