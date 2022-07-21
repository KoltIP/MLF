using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.UserAccountService.Models
{
    public class PasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class PasswordModelValidator : AbstractValidator<PasswordModel>
    {
        public PasswordModelValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New user password is required.")
                .MinimumLength(8).WithMessage("New user password is short.(minimum 8 characters).")
                .MaximumLength(50).WithMessage("New user password is long.(maximum 50 characters).");
        }
    }
}
