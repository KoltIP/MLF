﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetProject.Api.Controllers.Comment.Models;
using PetProject.CommentServices;
using PetProject.CommentServices.Models;
using PetProject.Db.Entities.User;

namespace PetProject.Api.Controllers.Comment
{
    [Route("api/v{version:apiVersion}/comments")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CommentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<CommentController> logger;
        private readonly ICommentService commentService;

        public CommentController(IMapper mapper, ILogger<CommentController> logger, ICommentService commentService, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.commentService = commentService;
        }

        [HttpGet("get/many/{advertisementId}")]
        public async Task<IEnumerable<CommentResponse>> GetCommentByAdvertisementId([FromRoute] int advertisementId)
        {
            var comments = await commentService.GetCommentsByAdvertisementId(advertisementId);
            var response = mapper.Map<IEnumerable<CommentResponse>>(comments);
            return response;
        }

        [HttpGet("get/one/{id}")]
        public async Task<CommentResponse> GetCommentByCommentId([FromRoute] int id)
        {
            var comment = await commentService.GetCommentByCommentId(id);
            var response = mapper.Map<CommentResponse>(comment);
            return response;
        }

        [HttpPost("add")]
        public async Task<CommentResponse> AddCommentAsync([FromBody] AddCommentRequest request)
        {
            var model = mapper.Map<AddCommentModel>(request);
            var comment = await commentService.AddComment(model);
            var result = mapper.Map<CommentResponse>(comment);
            return result;
        }

        [HttpPut("update/{commentId}")]
        public async Task<IActionResult> UpdateCommentAsync([FromRoute] int commentId, [FromBody] UpdateCommentRequest request)
        {
            var model = mapper.Map<UpdateCommentModel>(request);
            await commentService.UpdateComment(commentId, model);
            return Ok();
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCommentAsync([FromRoute] int id)
        {

            await commentService.DeleteComment(id);
            return Ok();
        }

    }
}
