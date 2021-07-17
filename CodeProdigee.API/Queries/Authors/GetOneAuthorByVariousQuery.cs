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
    public class GetOneAuthorByVariousQuery : IRequest<AuthorsListDto>
    {
        public string AuthorEmail { get; set; }

        public string AuthorGithub { get; set; }

        public string AuthorTwitter { get; set; }

    }


    public class GetOneAuthorByVariousQueryHandler : IRequestHandler<GetOneAuthorByVariousQuery, AuthorsListDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;
        public GetOneAuthorByVariousQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<AuthorsListDto> Handle(GetOneAuthorByVariousQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Authors.AsNoTracking()
                .Include(a => a.AuthorPosts)
                .Where(a => 
                !string.IsNullOrEmpty(a.AuthorEmail) && a.AuthorEmail.Contains(request.AuthorEmail) &&
                !string.IsNullOrEmpty(a.AuthorGithub) && a.AuthorGithub.Contains(request.AuthorGithub) &&
                !string.IsNullOrEmpty(a.AuthorTwitter) && a.AuthorTwitter.Contains(request.AuthorTwitter)
                ).Select(a => new AuthorsListDto
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
