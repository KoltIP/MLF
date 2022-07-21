using AutoMapper;
using FluentValidation;
using PetProject.UserAccountService.Models;

namespace PetProject.Api.Controllers.Account.Models
{
    public class RegistrationUserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegistrationUserRequestValidator : AbstractValidator<RegistrationUserRequest>
    {
        public RegistrationUserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("User name is required.")
                .MinimumLength(3).WithMessage("User name is short")
                .MaximumLength(50).WithMessage("User name is long");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("User surname is required.")
                .MinimumLength(3).WithMessage("User surname is short")
                .MaximumLength(50).WithMessage("User surname is long");

            RuleFor(x => x.Patronymic)
                .MinimumLength(3).WithMessage("User patronymic is long")
                .MaximumLength(50).WithMessage("User patronymic is long");

            //RuleFor(x => x.Phone)
            //    .NotEmpty().WithMessage("User surname is required.");

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

    public class RegistrationUserRequestProfile : Profile
    {
        public RegistrationUserRequestProfile()
        {
            CreateMap<RegistrationUserRequest, RegistrationUserModel>();
        }
    }
}
