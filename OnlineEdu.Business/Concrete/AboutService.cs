using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class AboutService(IRepository<About> _repository, IMapper _mapper) : IAboutService
    {
        public async Task CreateAbout(CreateAboutDto dto)
        {
            var result = _mapper.Map<About>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteAbout(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetAboutByIdDto> GetAboutById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetAboutByIdDto>(value);
        }

        public async Task<List<ResultAboutDto>> GetAboutList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultAboutDto>>(values);
        }

        public async Task UpdateAbout(UpdateAboutDto dto)
        {
            var value = _mapper.Map<About>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
