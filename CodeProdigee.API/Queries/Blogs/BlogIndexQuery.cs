using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Blogs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Blogs
{
    public class BlogIndexQuery : IRequest<List<BlogDto>>
    {
        public int PageCount { get; set; }

        public int PageSize { get; set; }
    }

    public class BlogIndexQueryHandler : IRequestHandler<BlogIndexQuery, List<BlogDto>>
    {
        private readonly CodeProdigeeContext _context;
        public BlogIndexQueryHandler(CodeProdigeeContext context)
        {
            _context = context;
        }

        public async Task<List<BlogDto>> Handle(BlogIndexQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Blogs.AsNoTracking().Include(b => b.Posts);
            var result = await query.Select(b => new BlogDto
            {
                AdminName = b.AdminName,
                BlogAdminEmail = b.BlogAdminEmail,
                BlogID = b.ID,
                BlogName = b.BlogName,
                PostsCount = b.Posts.Count
            }).ToListAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
