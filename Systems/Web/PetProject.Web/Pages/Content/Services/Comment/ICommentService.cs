using PetProject.Web.Pages.Content.Models.Comment;
using PetProject.Web.Pages.Profile.Models;

namespace PetProject.Web.Pages.Content.Services.Comment
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentListItem>> GetComments(int advertisementId);
        Task<CommentListItem> GetComment(int id);
        Task<ErrorResponse> AddComment(CommentModel model);
        Task<ErrorResponse> UpdateComment(int commentId, CommentModel model);
        Task<ErrorResponse> DeleteComment(int commentId);
    }
}
