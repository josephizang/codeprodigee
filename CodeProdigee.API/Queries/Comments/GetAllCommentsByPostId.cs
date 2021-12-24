using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos;
using CodeProdigee.API.Dtos.CommentReplies;
using CodeProdigee.API.Dtos.Comments;
using CodeProdigee.API.Dtos.Reactions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Comments
{
    public class GetAllCommentsByPostId : IRequest<CollectionResponse<List<CommentDto>>>
    {
        public Guid PostId { get; set; }
    }

    public class GetAllCommentsByPostIdHandler : IRequestHandler<GetAllCommentsByPostId, CollectionResponse<List<CommentDto>>>
    {
        private readonly CodeProdigeeContext _context;

        public GetAllCommentsByPostIdHandler(CodeProdigeeContext context)
        {
            _context = context;
        }
        public async Task<CollectionResponse<List<CommentDto>>> Handle(GetAllCommentsByPostId request, CancellationToken cancellationToken)
        {
            var query = _context.Comments.AsNoTracking()
                .Include(c => c.Post)
                .Include(c => c.CommentAuthor)
                .Include(c => c.Replies);

            var result = await query.Where(c => c.PostID == request.PostId)
                .Select(c => new CommentDto
                {
                    Reactions = c.CommentReactions.Select(x => new ReactionDto
                    {
                        CreatedOn = x.CreatedAt,
                        DisLike = x.DisLike,
                        Like = x.Like,
                        Email = x.Email
                    }).ToList(),
                    PostID = request.PostId,
                    Title = c.Title,
                    CommentBody = c.CommentBody,
                    CommentAuthorID = c.CommentAuthorID,
                    CreatedOn = c.CreatedAt
                }).OrderBy(x => x.CreatedOn).ToListAsync(cancellationToken).ConfigureAwait(false);

            var replies = await _context.Comments.Include(c => c.Replies)
                .Where(c => c.Replies.Any())
                .Select(c => new CommentReplyDto
                {
                    CommentId = c.ID,
                    Reactions = c.CommentReactions.Select(r => new ReactionDto
                    {
                        Like = r.Like,
                        DisLike = r.DisLike,
                        Email = r.Email,
                        CreatedOn = r.CreatedAt
                    }).ToList(),
                    ReplyBody = c.Replies.SingleOrDefault().ReplyBody
                }).ToListAsync(cancellationToken).ConfigureAwait(false);

            result.ForEach(x => x.Replies = replies);

            return new CollectionResponse<List<CommentDto>>(result);
        }
    }
}
