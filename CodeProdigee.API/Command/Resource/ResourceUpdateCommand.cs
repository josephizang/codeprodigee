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
    public class ResourceUpdateCommand : IRequest<ResourceProcessedDto>
    {
        public Guid ResourceID { get; set; }

        public string ResourceUrl { get; set; }

        public string Description { get; set; }


    }

    public class ResourceUpdateCommandHandler : IRequestHandler<ResourceUpdateCommand, ResourceProcessedDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public ResourceUpdateCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResourceProcessedDto> Handle(ResourceUpdateCommand request, CancellationToken cancellationToken)
        {
            var target = await _context.Resources.FindAsync(request.ResourceID, cancellationToken).ConfigureAwait(false);
            target.ResourceUrl = request.ResourceUrl;
            target.Description = request.Description;

            _context.Entry(target).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return new ResourceProcessedDto { ResourceID = target.ID };
        }
    }
}
