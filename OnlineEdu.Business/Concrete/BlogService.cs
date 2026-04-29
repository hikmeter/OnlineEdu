using AutoMapper;
using FluentValidation;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class BlogService(IRepository<Blog> _repository, IBlogRepository _blogRepository, IMapper _mapper, IValidator<CreateBlogDto> _createValidator, IValidator<UpdateBlogDto> _updateValidator) : IBlogService
    {
        public async Task CreateBlog(CreateBlogDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = _mapper.Map<Blog>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteBlog(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<GetAllBlogsWithCategoriesDto>> GetAllBlogsWithCategories()
        {
            var values = await _blogRepository.GetAllBlogsWithCategories();
            return _mapper.Map<List<GetAllBlogsWithCategoriesDto>>(values);
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
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var value = _mapper.Map<Blog>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}