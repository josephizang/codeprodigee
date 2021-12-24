using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Commentators;
using CodeProdigee.API.Dtos.Comments;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Posts
{
    public class PostIndexQuery : IRequest<List<PostDto>>
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }


    public class PostIndexQueryHandler : IRequestHandler<PostIndexQuery, List<PostDto>>
    {
        private readonly CodeProdigeeContext _context;

        public PostIndexQueryHandler(CodeProdigeeContext context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> Handle(PostIndexQuery request, CancellationToken cancellationToken)
        {
            var targetDate = DateTimeOffset.UtcNow.LocalDateTime;
            IQueryable<Post> query = _context.Posts
                 .AsNoTracking()
                 .Include(p => p.Comments)
                 .Include(p => p.Resources)
                 .Include(p => p.PostAuthor)
                 .Include(p => p.Tags);
            query = query.Where(p => p.PostDate <= targetDate.AddMonths(-3));
            query = query.OrderBy(p => p.PublishDate)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);
            var result = await query.Select(p => new PostDto
            {
                PublishDate = p.PublishDate,
                Postbody = p.PostBody,
                PostTitle = p.PostTitle,
                PostAuthor = $"{p.PostAuthor.FirstName} {p.PostAuthor.LastName}",
                AuthorID = Guid.Parse(p.AuthorID),
                PostDate = p.PostDate,
                PostID = p.ID,
                PublishPost = p.PublishPost,
                Resources = p.Resources.Select(r => new ResourceDto { ResourceUrl = r.ResourceUrl, Type = r.PostResourceType }).ToList(),
                Comments = p.Comments.Select(c => new CommentDto
                {
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
            }).ToListAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
