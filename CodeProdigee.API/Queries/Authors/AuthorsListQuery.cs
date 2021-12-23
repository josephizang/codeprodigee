using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorsListQueryHandler(CodeProdigeeContext context, IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mediator = mediator;
            _userManager = userManager;
        }
        public async Task<List<AuthorsListDto>> Handle(AuthorsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _userManager.Users.AsNoTracking();
                var result = await query
                        .Select(a => new AuthorsListDto
                        {
                            AuthorID = Guid.Parse(a.Id),
                            Bio = a.Bio,
                            AuthorGithub = a.AuthorGithub,
                            AuthorEmail = a.Email,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
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
