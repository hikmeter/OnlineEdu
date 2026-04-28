using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class SocialMediaService(IRepository<SocialMedia> _repository, IMapper _mapper) : ISocialMediaService
    {
        public async Task CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var result = _mapper.Map<SocialMedia>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteSocialMedia(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetSocialMediaByIdDto> GetSocialMediaById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetSocialMediaByIdDto>(value);
        }

        public async Task<List<ResultSocialMediaDto>> GetSocialMediaList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(values);
        }

        public async Task UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var value = _mapper.Map<SocialMedia>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
