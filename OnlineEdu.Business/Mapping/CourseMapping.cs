using AutoMapper;
using OnlineEdu.Dto.Dtos.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();
            CreateMap<ResultCourseDto, Course>().ReverseMap();
            CreateMap<GetCourseByIdDto, Course>().ReverseMap();
        }
    }
}
