using FluentValidation;
using OnlineEdu.Dto.Dtos.SubscriberDtos;

namespace OnlineEdu.Business.Validators.SubscriberValidators
{
    public class UpdateSubscriberDtoValidator : AbstractValidator<UpdateSubscriberDto>
    {
        public UpdateSubscriberDtoValidator()
        {
            RuleFor(x => x.SubscriberId).NotEmpty().WithMessage("Abone ID alanı boş olamaz.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.")
            .MaximumLength(50).WithMessage("Email en fazla 50 karakter olabilir.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Aktiflik bilgisi boş olamaz.");
        }
    }
}
