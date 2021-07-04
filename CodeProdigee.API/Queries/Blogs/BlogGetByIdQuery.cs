using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Blogs;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Blogs
{
    public class BlogGetByIdQuery : IRequest<BlogDto>
    {
        public Guid BlogID { get; set; }
    }

    public class BlogGetByIdQueryHandler : IRequestHandler<BlogGetByIdQuery, BlogDto>
    {

        private readonly CodeProdigeeContext _context;

        public BlogGetByIdQueryHandler(IMapper mapper, CodeProdigeeContext context)
        {
            _context = context;
        }
        public async Task<BlogDto> Handle(BlogGetByIdQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Blogs.AsNoTracking()
                .Include(b => b.Posts)
                .Where(blog => blog.ID.Equals(request.BlogID));

            var result = await query.Select(x => new BlogDto
            {
                AdminName = x.AdminName,
                BlogAdminEmail = x.BlogAdminEmail,
                BlogName = x.BlogName,
                PostsCount = x.Posts.Count,
                BlogID = x.ID
            }).SingleOrDefaultAsync(CancellationToken.None).ConfigureAwait(false);

            return result;
        }
    }
}
