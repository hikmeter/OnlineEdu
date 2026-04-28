using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogCategoryService(IRepository<BlogCategory> _repository, IMapper _mapper) : IBlogCategoryService
    {
        public async Task CreateBlogCategory(CreateBlogCategoryDto dto)
        {
            var result = _mapper.Map<BlogCategory>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteBlogCategory(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetBlogCategoryByIdDto> GetBlogCategoryById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetBlogCategoryByIdDto>(value);
        }

        public async Task<List<ResultBlogCategoryDto>> GetBlogCategoryList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultBlogCategoryDto>>(values);
        }

        public async Task UpdateBlogCategory(UpdateBlogCategoryDto dto)
        {
            var value = _mapper.Map<BlogCategory>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
