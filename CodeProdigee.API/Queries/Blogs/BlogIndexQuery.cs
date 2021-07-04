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
    public class BlogIndexQuery : IRequest<List<BlogDto>>
    {
        public int PageCount { get; set; }

        public int PageSize { get; set; }
    }

    public class BlogIndexQueryHandler : IRequestHandler<BlogIndexQuery, List<BlogDto>>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMapper _mapper;
        public BlogIndexQueryHandler(CodeProdigeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BlogDto>> Handle(BlogIndexQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Blogs.AsNoTracking();
            var result = await _mapper.From(query).ProjectToType<BlogDto>().ToListAsync().ConfigureAwait(false);
            return result;
        }
    }
}
