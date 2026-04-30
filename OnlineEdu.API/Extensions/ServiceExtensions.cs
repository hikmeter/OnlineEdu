using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Repositories;

namespace OnlineEdu.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICourseCategoryRepository), typeof(CourseCategoryRepository));
            services.AddScoped(typeof(ICourseRepository), typeof(CourseRepository));
            services.AddScoped(typeof(IAboutService), typeof(AboutService));
            services.AddScoped(typeof(IBannerService), typeof(BannerService));
            services.AddScoped(typeof(IBlogService), typeof(BlogService));
            services.AddScoped(typeof(IBlogCategoryService), typeof(BlogCategoryService));
            services.AddScoped(typeof(IContactService), typeof(ContactService));
            services.AddScoped(typeof(ICourseCategoryService), typeof(CourseCategoryService));
            services.AddScoped(typeof(ICourseService), typeof(CourseService));
            services.AddScoped(typeof(IMessageService), typeof(MessageService));
            services.AddScoped(typeof(ISocialMediaService), typeof(SocialMediaService));
            services.AddScoped(typeof(ISubscriberService), typeof(SubscriberService));
            services.AddScoped(typeof(ITestimonialService), typeof(TestimonialService));
        }
    }
}
