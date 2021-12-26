using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Comments
{
    public class AddCommentCommand : IRequest<Response<Guid>>
    {
        public Guid PostId { get; set; } = Guid.Empty;

        public string CommentBody { get; set; } = string.Empty;

        public Guid CommentatorId { get; set; } = Guid.Empty;

        public string Title { get; set; } = string.Empty;

    }


    public class AddCommentHandler : IRequestHandler<AddCommentCommand, Response<Guid>>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IContentFilter _contentFilter;

        public AddCommentHandler(CodeProdigeeContext context, IContentFilter contentFilter)
        {
            _context = context;
            _contentFilter = contentFilter;
        }
        public async Task<Response<Guid>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Commentators.AsNoTracking().AnyAsync(x => x.ID == request.CommentatorId) &&
                !await _context.Posts.AsNoTracking().AnyAsync(p => p.ID == request.PostId))
            {
                var errorResponse = new Response<Guid>("You cannot add comments to non existent posts when you are not registered!");
                return errorResponse;
            }

            var comment = new Comment
            {
                PostID = request.PostId,
                CommentAuthorID = request.CommentatorId,
                CommentBody = request.CommentBody,
                Title = request.Title
            };

            if (!string.IsNullOrEmpty(request.CommentBody) && await _contentFilter.CheckContent(request.CommentBody) == false)
            {
                comment.CommentBody = request.CommentBody;
            }

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var response = new Response<Guid>(comment.ID);
            response.Success = true;
            return response;
        }
    }
}
