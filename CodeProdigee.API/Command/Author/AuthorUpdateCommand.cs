using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Author
{
    public class AuthorUpdateCommand : IRequest<AuthorProcessedDto>
    {
        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorTwitter { get; set; }

        public string AuthorGithub { get; set; }

        public string AuthorAvatar { get; set; }

        public string Bio { get; set; }

        public Guid AuthorID { get; set; }
    }


    public class AuthorUpdateCommandHandler : IRequestHandler<AuthorUpdateCommand, AuthorProcessedDto>
    {
        private readonly IMediator _mediator;
        private readonly CodeProdigeeContext _context;

        public AuthorUpdateCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<AuthorProcessedDto> Handle(AuthorUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _context.Authors
                        .FindAsync(request.AuthorID, cancellationToken)
                        .ConfigureAwait(false);

                author.AuthorName = request.AuthorName;
                author.AuthorEmail = request.AuthorEmail;
                author.AuthorGithub = request.AuthorGithub;
                author.AvatarImage = request.AuthorAvatar;
                author.AuthorTwitter = request.AuthorTwitter;
                author.Bio = request.Bio;

                _context.Entry(author).State = EntityState.Modified;

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return new AuthorProcessedDto { AuthorID = author.ID };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
