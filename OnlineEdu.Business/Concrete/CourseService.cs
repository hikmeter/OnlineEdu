using AutoMapper;
using FluentValidation;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseService(IRepository<Course> _repository, ICourseRepository _courseRepository, IMapper _mapper, IValidator<CreateCourseDto> _createValidator, IValidator<UpdateCourseDto> _updateValidator) : ICourseService
    {
        public async Task CreateCourse(CreateCourseDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = _mapper.Map<Course>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteCourse(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultCourseDto>> Get3ActivePopularCourses()
        {
            var values = await _courseRepository.Get3ActivePopularCoursesAsync();
            return _mapper.Map<List<ResultCourseDto>>(values);
        }

        public async Task<GetCourseByIdDto> GetCourseById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetCourseByIdDto>(value);
        }

        public Task<int> GetCourseCount()
        {
            return _repository.CountAsync();
        }

        public async Task<List<ResultCourseDto>> GetCourseList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultCourseDto>>(values);
        }

        public async Task<List<GetCoursesWithCategoriesDto>> GetCoursesByCategoryId(int id)
        {
            var values = await _courseRepository.GetCoursesBCategoryIdAsync(id);
            return _mapper.Map<List<GetCoursesWithCategoriesDto>>(values);
        }

        public async Task<List<GetCoursesWithCategoriesDto>> GetCoursesByTeacherId(int id)
        {
            var values = await _courseRepository.GetCoursesByTeacherIdAsync(id);
            return _mapper.Map<List<GetCoursesWithCategoriesDto>>(values);
        }

        public async Task<List<GetCoursesWithCategoriesDto>> GetCoursesWithCategories()
        {
            var values = await _courseRepository.GetCoursesWithCategoriesAsync();
            return _mapper.Map<List<GetCoursesWithCategoriesDto>>(values);
        }

        public async Task<Course> ToggleShownStatus(int id)
        {
            var value = await _courseRepository.ToggleShownStatus(id);
            return value;
        }

        public async Task UpdateCourse(UpdateCourseDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var value = _mapper.Map<Course>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
