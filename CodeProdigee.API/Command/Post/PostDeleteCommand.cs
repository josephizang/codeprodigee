using CodeProdigee.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Post
{
    public class PostDeleteCommand : IRequest
    {
        public Guid PostID { get; set; }
    }


    public class PostDeleteCommandHandler : IRequestHandler<PostDeleteCommand, Unit>
    {
        private readonly CodeProdigeeContext _context;

        private readonly IMediator _mediator;

        public PostDeleteCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(PostDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _context.Posts.FindAsync(request.PostID, cancellationToken).ConfigureAwait(false);

                post.IsDeleted = true;

                _context.Entry(post).State = EntityState.Modified;

                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
