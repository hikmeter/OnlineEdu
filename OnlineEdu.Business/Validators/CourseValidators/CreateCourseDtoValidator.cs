using FluentValidation;
using OnlineEdu.Dto.Dtos.CourseDtos;

namespace OnlineEdu.Business.Validators.CourseValidators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(x => x.CourseName)
            .NotEmpty().WithMessage("Kurs adı boş olamaz.")
            .MinimumLength(3).WithMessage("Kurs adı en az 3 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kurs adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .Must(BeAValidUrl).WithMessage("Geçerli bir URL giriniz.");

            RuleFor(x => x.CourseCategoryId)
                .NotEmpty().WithMessage("Kategori seçimi zorunludur.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat 0'dan küçük olamaz.");

            RuleFor(x => x.IsShown)
                .NotNull().WithMessage("Görünürlük bilgisi boş olamaz.");
        }
        private bool BeAValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
