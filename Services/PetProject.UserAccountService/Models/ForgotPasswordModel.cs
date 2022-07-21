using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.UserAccountService.Models
{
    public class ForgotPasswordModel
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("User email is required")
                .MinimumLength(5).WithMessage("User email is short")
                .MaximumLength(50).WithMessage("User email is long")
                .EmailAddress().WithMessage("User email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("User password is required")
                .MinimumLength(8).WithMessage("User password is short.(minimum 8 characters).")
                .MaximumLength(50).WithMessage("User password is long.(maximum 50 characters).");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ForgotPasswordModel>.CreateWithOptions((ForgotPasswordModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
