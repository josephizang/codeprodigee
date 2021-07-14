using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Authors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Authors
{
    public class AuthorsListQuery : IRequest<List<AuthorsListDto>>
    {
    }


    public class AuthorsListQueryHandler : IRequestHandler<AuthorsListQuery, List<AuthorsListDto>>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;
        public AuthorsListQueryHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<List<AuthorsListDto>> Handle(AuthorsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
