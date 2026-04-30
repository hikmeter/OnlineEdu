using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseCategoryService(IRepository<CourseCategory> _repository, ICourseCategoryRepository _categoryRepository, IMapper _mapper) : ICourseCategoryService
    {
        public async Task CreateCourseCategory(CreateCourseCategoryDto dto)
        {
            var result = _mapper.Map<CourseCategory>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteCourseCategory(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultCourseCategoryDto>> GetActiveCourseCategories()
        {
            var values = await _categoryRepository.GetActiveCourseCategoriesAsync();
            return _mapper.Map<List<ResultCourseCategoryDto>>(values);
        }

        public async Task<GetCourseCategoryByIdDto> GetCourseCategoryById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetCourseCategoryByIdDto>(value);
        }

        public async Task<List<ResultCourseCategoryDto>> GetCourseCategoryList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultCourseCategoryDto>>(values);
        }

        public async Task<CourseCategory> ToggleShownStatus(int id)
        {
            var value = await _categoryRepository.ToggleShownStatus(id);
            return value;
        }

        public async Task UpdateCourseCategory(UpdateCourseCategoryDto dto)
        {
            var value = _mapper.Map<CourseCategory>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
