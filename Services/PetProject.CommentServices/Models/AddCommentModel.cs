using AutoMapper;
using FluentValidation;
using PetProject.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.CommentServices.Models
{
    public class AddCommentModel
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public int AdvertisementId { get; set; }
    }
    public class AddCommentModelValidator : AbstractValidator<AddCommentModel>
    {
        public AddCommentModelValidator()
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
    public class AddCommentModelProfile : Profile
    {
        public AddCommentModelProfile()
        {
            CreateMap<AddCommentModel, Comment>();
        }
    }
}
