using AutoMapper;
using FluentValidation;
using PetProject.UserAccountService.Models;

namespace PetProject.Api.Controllers.Account.Models
{
    public class PasswordRequest
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
    public class PasswordRequestValidator : AbstractValidator<PasswordRequest>
    {
        public PasswordRequestValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New user password is required.")
                .MinimumLength(8).WithMessage("New user password is short.(minimum 8 characters).")
                .MaximumLength(50).WithMessage("New user password is long.(maximum 50 characters).");
        }
    }

    public class PasswordRequestProfile : Profile
    {
        public PasswordRequestProfile()
        {
            CreateMap<PasswordRequest, PasswordModel>()
                .ForMember(d => d.NewPassword, a => a.MapFrom(s => s.NewPassword))
                .ForMember(d => d.OldPassword, a => a.MapFrom(s => s.OldPassword));
        }
    }
}
