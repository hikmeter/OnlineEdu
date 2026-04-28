using FluentValidation;
using OnlineEdu.Dto.Dtos.SubscriberDtos;

namespace OnlineEdu.Business.Validators.SubscriberValidators
{
    public class CreateSubscriberDtoValidator : AbstractValidator<CreateSubscriberDto>
    {
        public CreateSubscriberDtoValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email giriniz.")
            .MaximumLength(50).WithMessage("Email en fazla 50 karakter olabilir.");
        }
    }
}
