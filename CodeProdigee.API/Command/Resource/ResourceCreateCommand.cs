using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.EventNotifications.Resources;
using CodeProdigee.API.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Resource
{
    public class ResourceCreateCommand : IRequest<ResourceProcessedDto>
    {
        [StringLength(300)]
        [Required]
        public string ResourceUrl { get; set; }

        public string Description { get; set; }

        [Required]
        public ResourceType TypeOfResource { get; set; }
    }

    public class ResourceCreateCommandHandler : IRequestHandler<ResourceCreateCommand, ResourceProcessedDto>
    {
        private readonly IMediator _mediator;

        private readonly CodeProdigeeContext _context;

        public ResourceCreateCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<ResourceProcessedDto> Handle(ResourceCreateCommand request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException("Resource must be provided a url and a type!");
            try
            {
                var resource = new Models.Resource
                {
                    ResourceUrl = request.ResourceUrl,
                    Description = request.Description,
                    PostResourceType = request.TypeOfResource
                };

                _context.Resources.Add(resource);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                var resourceEvent = new ResourceCreatedNotification
                {
                    ResourceUrl = request.ResourceUrl,
                    DateAdded = resource.CreatedAt,
                    ResourceID = resource.ID
                };
                await _mediator.Publish(resourceEvent, cancellationToken).ConfigureAwait(false);
                return new ResourceProcessedDto { ResourceID = resource.ID };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
