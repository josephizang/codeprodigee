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
    public class GetOneAuthorQuery : IRequest<AuthorsListDto>
    {
        public Guid AuthorID { get; set; }
    }

    public class GetOneAuthorQueryHandler : IRequestHandler<GetOneAuthorQuery, AuthorsListDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public GetOneAuthorQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<AuthorsListDto> Handle(GetOneAuthorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Authors.AsNoTracking()
                .Include(a => a.AuthorPosts)
                .Where(a => a.ID == request.AuthorID)
                .Select(a => new AuthorsListDto
                {
                    AuthorEmail = a.AuthorEmail,
                    AuthorGithub = a.AuthorGithub,
                    AuthorID = a.ID,
                    AuthorName = a.AuthorName,
                    AuthorTwitter = a.AuthorTwitter,
                    Bio = a.Bio,
                    DateJoined = a.CreatedAt,
                    AuthorPostsCount = a.AuthorPosts.Count
                }).SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
