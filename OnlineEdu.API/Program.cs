using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.API.Extensions;
using OnlineEdu.Business.Mapping;
using OnlineEdu.Business.Validators.BlogValidators;
using OnlineEdu.Business.Validators.CourseValidators;
using OnlineEdu.Business.Validators.SubscriberValidators;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddServiceExtensions();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


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
builder.Services.AddAutoMapper(typeof(TeacherSocialMapping));
builder.Services.AddAutoMapper(typeof(CourseEnrollmentMapping));
builder.Services.AddAutoMapper(typeof(AppUserMapping));

builder.Services.AddValidatorsFromAssemblyContaining<CreateBlogDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateBlogDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCourseDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCourseDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateSubscriberDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateSubscriberDtoValidator>();
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
