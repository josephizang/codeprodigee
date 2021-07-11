using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Commentators;
using CodeProdigee.API.Dtos.Comments;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Dtos.Resources;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Posts
{
    public class GetOnePostQuery : IRequest<PostDto>
    {
        public Guid ID { get; set; }
    }

    public class GetOnePostQueryHandler : IRequestHandler<GetOnePostQuery, PostDto>
    {
        private readonly CodeProdigeeContext _context;
        public GetOnePostQueryHandler(CodeProdigeeContext context)
        {
            _context = context;
        }
        public async Task<PostDto> Handle(GetOnePostQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Posts.AsNoTracking()
                .Include(p => p.Comments)
                .ThenInclude(c => c.CommentAuthor)
                .Include(p => p.PostAuthor)
                .Include(p => p.Resources)
                .Include(p => p.Tags)
                .Where(p => p.ID.Equals(request.ID))
                .Select(p => new PostDto
                {
                    PublishDate = p.PublishDate,
                    Postbody = p.PostBody,
                    PostTitle = p.PostTitle,
                    PostAuthor = p.PostAuthor.AuthorName,
                    PostDate = p.PostDate,
                    AuthorID = p.AuthorID,
                    PostID = p.ID,
                    PublishPost = p.PublishPost,
                    Resources = p.Resources.Select(r => new ResourceDto { ResourceUrl = r.ResourceUrl, Type = r.PostResourceType }).ToList(),
                    Comments = p.Comments.Select(c => new CommentDto
                    {
                        DisLikes = c.DisLikes,
                        Likes = c.Likes,
                        Title = c.Title,
                        PostID = c.PostID,
                        CommentBody = c.CommentBody,
                        CommentAuthor = new CommentatorDto
                        {
                            Email = c.CommentAuthor.Email,
                            FullName = c.CommentAuthor.FullName
                        },
                        CommentAuthorID = c.CommentAuthorID
                    }).ToList()
                }).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
