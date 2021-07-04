using CodeProdigee.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Blog
{
    public class BlogUpdateCommand : IRequest<Guid>
    {
        public string BlogAdminEmail { get; set; }

        public string AdminName { get; set; }

        public string BlogName { get; set; }

        public Guid BlogID { get; set; }
    }


    public class BlogUpdateCommandHandler : IRequestHandler<BlogUpdateCommand, Guid>
    {
        private readonly CodeProdigeeContext _context;

        public BlogUpdateCommandHandler(CodeProdigeeContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(BlogUpdateCommand request, CancellationToken cancellationToken)
        {
            var resultingGuid = Guid.Empty;
            var target = await _context.Blogs.FindAsync(request.BlogID);
            try
            {
                if(target is not null
                    && request is not null 
                    && !string.IsNullOrEmpty(request.BlogAdminEmail)
                    && !string.IsNullOrEmpty(request.AdminName)
                    && !string.IsNullOrEmpty(request.BlogName)
                    && request.BlogID != resultingGuid)
                {
                    //get the right blog

                    target.BlogName = request.BlogName;
                    target.AdminName = request.AdminName;
                    target.BlogAdminEmail = request.BlogAdminEmail;
                    target.UpdatedAt = DateTimeOffset.UtcNow;
                    target.ID = request.BlogID;

                    _context.Entry(target).State = EntityState.Modified;
                    await _context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return target.ID;
                }
                throw new InvalidOperationException($"Blog Update Failed becuase blog with id {request.BlogID} was not found!!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
