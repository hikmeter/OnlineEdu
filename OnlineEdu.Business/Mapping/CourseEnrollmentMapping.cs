using AutoMapper;
using OnlineEdu.Dto.Dtos.CourseCategoryDtos;
using OnlineEdu.Dto.Dtos.CourseDtos;
using OnlineEdu.Dto.Dtos.CourseEnrollmentDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class CourseEnrollmentMapping : Profile
    {
        public CourseEnrollmentMapping()
        {
            CreateMap<CreateCourseEnrollmentDto, CourseEnrollment>().ReverseMap();
            CreateMap<UpdateCourseEnrollmentDto, CourseEnrollment>().ReverseMap();
            CreateMap<ResultCourseEnrollmentDto, CourseEnrollment>().ReverseMap();
            CreateMap<GetCourseEnrollmentByIdDto, CourseEnrollment>().ReverseMap();
            CreateMap<CourseEnrollment, GetCourseEnrollmentsWithCourseNamesDto>().ReverseMap();
            CreateMap<Course, GetCoursesWithCategoriesDto>().ReverseMap(); CreateMap<CourseCategory, ResultCourseCategoryDto>().ReverseMap();
        }
    }
}
