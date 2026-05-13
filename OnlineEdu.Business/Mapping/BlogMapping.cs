using AutoMapper;
using OnlineEdu.Dto.Dtos.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ForMember(dest => dest.BlogDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<ResultBlogDto, Blog>().ReverseMap();
            CreateMap<GetBlogByIdDto, Blog>().ReverseMap();
            CreateMap<Blog, GetAllBlogsWithCategoriesDto>().ForMember(dest => dest.BlogCategoryName, opt => opt.MapFrom(src => src.BlogCategory.Name)).ForMember(dest => dest.WriterName, opt => opt.MapFrom(src => src.Writer.Name + " " + src.Writer.Surname));
        }
    }
}
