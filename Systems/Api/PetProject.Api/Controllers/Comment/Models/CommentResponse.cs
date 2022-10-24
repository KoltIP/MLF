using AutoMapper;
using PetProject.CommentServices.Models;

namespace PetProject.Api.Controllers.Comment.Models
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int AdvertisementId { get; set; }
    }
    public class CommentResponseProfile : Profile
    {
        public CommentResponseProfile()
        {
            CreateMap<CommentModel, CommentResponse>();
        }
    }
}
