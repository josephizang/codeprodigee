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
    public class GetAResourceQuery : IRequest<ResourceDto>
    {
        public Guid ResourceID { get; set; }
    }

    public class GetAResourceQueryHandler : IRequestHandler<GetAResourceQuery, ResourceDto>
    {
        private readonly CodeProdigeeContext _context;

        public GetAResourceQueryHandler(CodeProdigeeContext context)
        {
            _context = context;
        }
        public async Task<ResourceDto> Handle(GetAResourceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Resources.AsNoTracking()
                    .Where(r => r.ID == request.ResourceID)
                    .Select(r => new ResourceDto
                    {
                        ResourceUrl = r.ResourceUrl,
                        Type = r.PostResourceType,
                        ResourceID = r.ID
                    }).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
