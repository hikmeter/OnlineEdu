using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BannerService(IRepository<Banner> _repository, IMapper _mapper) : IBannerService
    {
        public async Task CreateBanner(CreateBannerDto dto)
        {
            var result = _mapper.Map<Banner>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteBanner(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetBannerByIdDto> GetBannerById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetBannerByIdDto>(value);
        }

        public async Task<List<ResultBannerDto>> GetBannerList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task UpdateBanner(UpdateBannerDto dto)
        {
            var value = _mapper.Map<Banner>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
