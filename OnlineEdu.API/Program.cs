using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.Business.Mapping;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IAboutService), typeof(AboutService));
builder.Services.AddScoped(typeof(IBannerService), typeof(BannerService));
builder.Services.AddScoped(typeof(IBlogService), typeof(BlogService));
builder.Services.AddScoped(typeof(IBlogCategoryService), typeof(BlogCategoryService));
builder.Services.AddScoped(typeof(IContactService), typeof(ContactService));
builder.Services.AddScoped(typeof(ICourseCategoryService), typeof(CourseCategoryService));
builder.Services.AddScoped(typeof(ICourseService), typeof(CourseService));
builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));
builder.Services.AddScoped(typeof(ISocialMediaService), typeof(SocialMediaService));
builder.Services.AddScoped(typeof(ISubscriberService), typeof(SubscriberService));
builder.Services.AddScoped(typeof(ITestimonialService), typeof(TestimonialService));
builder.Services.AddAutoMapper(typeof(AboutMapping));
builder.Services.AddAutoMapper(typeof(BannerMapping));
builder.Services.AddAutoMapper(typeof(BlogMapping));
builder.Services.AddAutoMapper(typeof(BlogCategoryMapping));
builder.Services.AddAutoMapper(typeof(ContactMapping));
builder.Services.AddAutoMapper(typeof(CourseMapping));
builder.Services.AddAutoMapper(typeof(CourseCategoryMapping));
builder.Services.AddAutoMapper(typeof(MessageMapping));
builder.Services.AddAutoMapper(typeof(SocialMediaMapping));
builder.Services.AddAutoMapper(typeof(SubscriberMapping));
builder.Services.AddAutoMapper(typeof(TestimonialMapping));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
