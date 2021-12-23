using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Authors
{
    public class GetOneAuthorByVariousQuery : IRequest<AuthorsListDto>
    {
        public string SearchParam { get; set; }

    }


    public class GetOneAuthorByVariousQueryHandler : IRequestHandler<GetOneAuthorByVariousQuery, AuthorsListDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetOneAuthorByVariousQueryHandler(CodeProdigeeContext context, IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mediator = mediator;
            _userManager = userManager;
        }
        public async Task<AuthorsListDto> Handle(GetOneAuthorByVariousQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _userManager.Users.AsNoTracking()
                .Include(a => a.AuthorPosts)
                .Where(a =>
                !string.IsNullOrEmpty(a.Email) && a.Email.Contains(request.SearchParam) ||
                !string.IsNullOrEmpty(a.AuthorGithub) && a.AuthorGithub.Contains(request.SearchParam) ||
                !string.IsNullOrEmpty(a.AuthorTwitter) && a.AuthorTwitter.Contains(request.SearchParam)
                ).Select(a => new AuthorsListDto
                {
                    AuthorEmail = a.Email,
                    AuthorGithub = a.AuthorGithub,
                    AuthorID = Guid.Parse(a.Id),
                    FirstName = a.FirstName,
                    LastName = a.LastName,
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
