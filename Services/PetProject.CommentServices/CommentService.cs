using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetProject.CommentServices.Models;
using PetProject.Db.Context.Context;
using PetProject.Db.Entities;
using PetProject.RabbitMqService;
using PetProject.Shared.Common.Exceptions;
using PetProject.Shared.Common.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IMapper mapper;
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IModelValidator<AddCommentModel> addCommentModelValidator;
        private readonly IModelValidator<UpdateCommentModel> updateCommentModelValidator;
        private readonly IRabbitMqTask rabbitMqTask;

        public CommentService(IDbContextFactory<MainDbContext> contextFactory, IMapper mapper,
            IModelValidator<AddCommentModel> addCommentModelValidator,
             IModelValidator<UpdateCommentModel> updateCommentModelValidator, IRabbitMqTask rabbitMqTask
            )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addCommentModelValidator = addCommentModelValidator;
            this.updateCommentModelValidator = updateCommentModelValidator;
            this.rabbitMqTask = rabbitMqTask;
        }

        public async Task<CommentModel> AddComment(AddCommentModel model)
        {
            addCommentModelValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var comment = mapper.Map<Comment>(model);
            await context.Comments.AddAsync(comment);
            context.SaveChanges();

            NotificationSub(model.AdvertisementId);

            return mapper.Map<CommentModel>(comment);
        }





        private async Task NotificationSub(int advertisementId)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var subscriptions = context.Subscriptions.ToList();
            foreach (var subscription in subscriptions)
            {
                if (subscription.AdvertisementId == advertisementId)
                {
                    var user = context.Users.FirstOrDefault(x => x.Id == subscription.UserId);
                    if (user == null)
                        throw new ProcessException("The user was not found");

                    await rabbitMqTask.SendEmail(new RabbitMqService.Models.EmailModel()
                    {
                        Email = user.Email,
                        Subject = "PetProject",
                        Message = "A new comment has appeared on the server"
                    });
                }
            }
        }




        public async Task<CommentModel> GetCommentByCommentId(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var comment = await context.Comments.Include(x => x.User).FirstOrDefaultAsync(comment => comment.Id.Equals(id));

            var data = mapper.Map<CommentModel>(comment);

            return data;

        }

        public async Task<IEnumerable<CommentModel>> GetCommentsByAdvertisementId(int advertisementId)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var comments = context.Comments.Include(x => x.User).AsQueryable();

            var data = (await comments.ToListAsync()).Where(comment => comment.AdvertisementId == advertisementId);

            return mapper.Map<IEnumerable<CommentModel>>(data); ;
        }

        public async Task UpdateComment(int id, UpdateCommentModel model)
        {
            updateCommentModelValidator.Check(model);
            using var context = await contextFactory.CreateDbContextAsync();

            var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(id));
            ProcessException.ThrowIf(() => comment is null, $"The comment (id: {id}) was not found");
            comment = mapper.Map(model, comment);

            context.Comments.Update(comment);
            context.SaveChanges();

        }

        public async Task DeleteComment(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(id));
            ProcessException.ThrowIf(() => comment is null, $"The comment (id: {id}) was not found");

            context.Remove(comment);
            context.SaveChanges();
        }
    }
}
