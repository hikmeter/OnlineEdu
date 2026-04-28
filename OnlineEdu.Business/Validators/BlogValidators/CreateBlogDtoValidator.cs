using FluentValidation;
using OnlineEdu.Dto.Dtos.BlogDtos;

namespace OnlineEdu.Business.Validators.BlogValidators
{
    public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
    {
        public CreateBlogDtoValidator()
        {
            RuleFor(x => x.BlogCategoryId)
            .NotEmpty().WithMessage("Kategori seçimi zorunludur.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz.")
                .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter olabilir.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş bırakılamaz.")
                .MinimumLength(20).WithMessage("İçerik en az 20 karakter olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.")
                .Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute))
                .WithMessage("Geçerli bir görsel URL giriniz.");

            RuleFor(x => x.BlogDate)
                .NotEmpty().WithMessage("Blog tarihi boş bırakılamaz.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Blog tarihi gelecekte olamaz.");
        }
    }
}
