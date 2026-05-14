using AutoMapper;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.CourseEnrollmentDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class CourseEnrollmentService(IRepository<CourseEnrollment> _repository, ICourseEnrollmentRepository _enrollmentRepository, IMapper _mapper) : ICourseEnrollmentService
    {
        public async Task CreateCourseEnrollment(CreateCourseEnrollmentDto dto)
        {
            var result = _mapper.Map<CourseEnrollment>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteCourseEnrollment(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetCourseEnrollmentByIdDto> GetCourseEnrollmentById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetCourseEnrollmentByIdDto>(value);
        }

        public async Task<List<ResultCourseEnrollmentDto>> GetCourseEnrollmentList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultCourseEnrollmentDto>>(values);
        }

        public async Task<List<GetCourseEnrollmentsWithCourseNamesDto>> GetCourseEnrollmentsByStudentId(int id)
        {
            var values = await _enrollmentRepository.GetCourseEnrollmentsByStudentIdAsync(id);
            return _mapper.Map<List<GetCourseEnrollmentsWithCourseNamesDto>>(values);
        }

        public async Task<List<GetCourseEnrollmentsWithCourseNamesDto>> GetCourseEnrollmentsWithCourseNames()
        {
            var values = await _enrollmentRepository.GetAllCourseEnrollmentsWithCourseNamesAsync();
            return _mapper.Map<List<GetCourseEnrollmentsWithCourseNamesDto>>(values);
        }

        public async Task UpdateCourseEnrollment(UpdateCourseEnrollmentDto dto)
        {
            var value = _mapper.Map<CourseEnrollment>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
