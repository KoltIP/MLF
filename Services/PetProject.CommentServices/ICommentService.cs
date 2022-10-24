using PetProject.CommentServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetCommentsByAdvertisementId(int id);
        Task<CommentModel> GetCommentByCommentId(int id);
        Task<CommentModel> AddComment(AddCommentModel model);
        Task UpdateComment(int id, UpdateCommentModel model);
        Task DeleteComment(int id);
    }
}
