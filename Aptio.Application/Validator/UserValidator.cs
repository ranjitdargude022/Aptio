using Aptio.Application.Authentication;
using FluentValidation;

namespace Aptio.Application.Validator
{
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password) .NotEmpty() .MinimumLength(8);

            RuleFor(x => x.FirstName) .NotEmpty().MaximumLength(50);

            RuleFor(x => x.LastName).MaximumLength(50);

            RuleFor(x => x.Phone).MaximumLength(20);
        }
    }
}