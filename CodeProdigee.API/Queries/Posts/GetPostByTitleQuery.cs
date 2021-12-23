using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Dtos.Resources;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Posts
{
    public class GetPostByTitleQuery : IRequest<List<PostByTitleDto>>
    {
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string PostTitle { get; set; }
    }


    public class GetPostByTitleQueryHandler : IRequestHandler<GetPostByTitleQuery, List<PostByTitleDto>>
    {
        private readonly IMediator _mediator;
        private readonly CodeProdigeeContext _context;

        public GetPostByTitleQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<List<PostByTitleDto>> Handle(GetPostByTitleQuery request, CancellationToken cancellationToken)
        {
            var resources = new List<ResourceDto>();
            var query = _context.Posts.AsNoTracking()
                .Include(p => p.PostAuthor)
                .Include(p => p.Tags)
                .Include(p => p.Resources)
                .Where(p => p.PostTitle.Contains(request.PostTitle, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(p => p.PostTitle)
                .ThenBy(p => p.PublishDate);

            try
            {
                var result = await query.Select(p => new PostByTitleDto
                {
                    PublishDate = p.PublishDate,
                    PostTitle = p.PostTitle,
                    PostAuthor = $"{p.PostAuthor.FirstName} {p.PostAuthor.LastName}",
                    AuthorID = Guid.Parse(p.AuthorID),
                    PostID = p.ID,
                    PublishPost = p.PublishPost,
                    PostDate = p.PostDate,
                    NumberOfComments = p.Tags.Count
                }).ToListAsync(cancellationToken).ConfigureAwait(false);

                var counter = 0;

                while (counter <= result.Count)
                {
                    resources = await _context.Resources.AsNoTracking()
                    .Include(r => r.Posts.Where(x => x.ID == result[counter].PostID))
                    .Select(r => new ResourceDto
                    {
                        ResourceUrl = r.ResourceUrl,
                        Type = r.PostResourceType
                    }).ToListAsync(cancellationToken).ConfigureAwait(false);
                    result[counter].Resources = resources;
                    counter++;
                }

                return result;

                //create and persist a notification for successful read
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
