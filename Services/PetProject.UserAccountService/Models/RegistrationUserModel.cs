using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.UserAccountService.Models
{
    public class RegistrationUserModel
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;       
        public string Password { get; set; } = string.Empty;
    }

    public class RegistrationUserModelValidator : AbstractValidator<RegistrationUserModel>
    {
        public RegistrationUserModelValidator()
        {

            RuleFor(x => x.Nickname)
                .NotEmpty().WithMessage("Nickname is required.")
                .MinimumLength(3).WithMessage("Nickname is short")
                .MaximumLength(50).WithMessage("Nickname is long");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .MinimumLength(5).WithMessage("User email is short")
                .MaximumLength(50).WithMessage("User email is long")
                .EmailAddress().WithMessage("User email is required.");


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("User password is required.")
                .MinimumLength(8).WithMessage("User password is short.(minimum 8 characters).")
                .MaximumLength(50).WithMessage("User password is long.(maximum 50 characters).");
        }
    }
}
