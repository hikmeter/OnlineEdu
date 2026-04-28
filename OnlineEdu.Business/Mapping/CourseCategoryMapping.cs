using AutoMapper;
using OnlineEdu.Dto.Dtos.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class CourseCategoryMapping : Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CreateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<GetCourseCategoryByIdDto, CourseCategory>().ReverseMap();
        }
    }
}
