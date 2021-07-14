using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using CodeProdigee.API.EventNotifications.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Author
{
    public class AuthorCreateCommand : IRequest<AuthorProcessedDto>
    {
        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorTwitter { get; set; }

        public string AuthorGithub { get; set; }

        public string AuthorAvatar { get; set; }

        public string Bio { get; set; }
    }


    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, AuthorProcessedDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public AuthorCreateCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<AuthorProcessedDto> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            var author = new Models.Author
            {
                AvatarImage = request.AuthorAvatar,
                AuthorName = request.AuthorName,
                AuthorEmail = request.AuthorEmail,
                AuthorGithub = request.AuthorGithub,
                AuthorTwitter = request.AuthorTwitter,
                Bio = request.Bio
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync(cancellationToken);
            await _mediator
                .Publish(new AuthorCreatedNotification { AuthorID = author.ID }, cancellationToken)
                .ConfigureAwait(false);
            return new AuthorProcessedDto { AuthorID = author.ID };
        }
    }
}
