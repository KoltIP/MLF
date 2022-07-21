using AutoMapper;
using FluentValidation;
using PetProject.UserAccountService.Models;

namespace PetProject.Api.Controllers.Account.Models
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
    public class ResetPasswordUserRequestValidator : AbstractValidator<ForgotPasswordRequest>
    {
        public ResetPasswordUserRequestValidator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("User email is required")
                 .MinimumLength(5).WithMessage("User email is short")
                 .MaximumLength(50).WithMessage("User patronymic is long")
                 .EmailAddress().WithMessage("User email is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("User password is required")
                .MinimumLength(8).WithMessage("User password is short.(minimum 8 characters).")
                .MaximumLength(50).WithMessage("User password is long.(maximum 50 characters).");
        }
    }
    public class ForgotPasswordRequestProfile : Profile
    {
        public ForgotPasswordRequestProfile()
        {
            CreateMap<ForgotPasswordRequest, ForgotPasswordModel>();
        }
    }
}
