using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogService(IRepository<Blog> _repository, IMapper _mapper) : IBlogService
    {
        public async Task CreateBlog(CreateBlogDto dto)
        {
            var result = _mapper.Map<Blog>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteBlog(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetBlogByIdDto> GetBlogById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetBlogByIdDto>(value);
        }

        public async Task<List<ResultBlogDto>> GetBlogList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task UpdateBlog(UpdateBlogDto dto)
        {
            var value = _mapper.Map<Blog>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}