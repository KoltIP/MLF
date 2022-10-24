using AutoMapper;
using FluentValidation;
using PetProject.CommentServices.Models;

namespace PetProject.Api.Controllers.Comment.Models
{
    public class AddCommentRequest
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }
    public class AddCommentRequestValidator : AbstractValidator<AddCommentRequest>
    {
        public AddCommentRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MaximumLength(1000).WithMessage("Content is long");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User is required");
            RuleFor(x => x.AdvertisementId)
                .NotEmpty().WithMessage("Advertisement is required");
        }
    }
    public class AddCommentRequestProfile : Profile
    {
        public AddCommentRequestProfile()
        {
            CreateMap<AddCommentRequest, AddCommentModel>();
        }
    }
}
