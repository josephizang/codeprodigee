using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Resources;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Resources
{
    public class GetResourcesQuery : IRequest<List<ResourceListDto>>
    {
        public string SearchString { get; set; } = "";
        
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }


    public class GetResourceQueryHandler : IRequestHandler<GetResourcesQuery, List<ResourceListDto>>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public GetResourceQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<List<ResourceListDto>> Handle(GetResourcesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = await _context.Resources.AsNoTracking()
                .Include(r => r.PostResources)
                .Select(r => new ResourceListDto
                {
                    DateCreated = r.CreatedAt,
                    ResourceID = r.ID,
                    ResourceUrl = r.ResourceUrl,
                    Type = r.PostResourceType,
                    NumberOfUses = r.PostResources.Count
                }).ToListAsync(cancellationToken).ConfigureAwait(false);
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
