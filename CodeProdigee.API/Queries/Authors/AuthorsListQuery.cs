using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Authors
{
    public class AuthorsListQuery : IRequest<List<AuthorsListDto>>
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }


    public class AuthorsListQueryHandler : IRequestHandler<AuthorsListQuery, List<AuthorsListDto>>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;
        public AuthorsListQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<List<AuthorsListDto>> Handle(AuthorsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.Authors.AsNoTracking()
                        .Include(a => a.AuthorPosts);
                var result = await query
                        .Select(a => new AuthorsListDto
                        {
                            AuthorID = a.ID,
                            Bio = a.Bio,
                            AuthorGithub = a.AuthorGithub,
                            AuthorEmail = a.AuthorEmail,
                            AuthorName = a.AuthorName,
                            AuthorTwitter = a.AuthorTwitter,
                            AuthorPostsCount = a.AuthorPosts.Count,
                            DateJoined = a.CreatedAt
                        }).OrderBy(a => a.DateJoined)
                        .ToListAsync(cancellationToken)
                        .ConfigureAwait(false);
                // consider doing audit trail where visitors are tracked and stored in db or some other medium
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
