using CodeProdigee.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Author
{
    public class AuthorDeleteCommand : IRequest
    {
        public Guid AuthorID { get; set; }
    }

    public class AuthorDeleteCommandHandler : IRequestHandler<AuthorDeleteCommand, Unit>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;
        public AuthorDeleteCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(AuthorDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Authors.FindAsync(request.AuthorID).ConfigureAwait(false);

                query.IsDeleted = true;

                _context.Entry(query).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return default;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
