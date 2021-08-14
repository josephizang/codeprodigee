using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Resources;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Resource
{
    public class ResourceDeleteCommand : IRequest<ResourceProcessedDto>
    {
        public Guid ResourceID { get; set; }
    }


    public class ResourceDeleteCommandHandler : IRequestHandler<ResourceDeleteCommand, ResourceProcessedDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public ResourceDeleteCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResourceProcessedDto> Handle(ResourceDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var target = await _context.Resources.FindAsync(request.ResourceID, cancellationToken).ConfigureAwait(false);
                target.IsDeleted = true;
                _context.Entry(target).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return new ResourceProcessedDto { ResourceID = target.ID };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
