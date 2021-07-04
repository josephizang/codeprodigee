using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Blogs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace CodeProdigee.API.Command.Blog
{
    public class BlogCreationCommand : IRequest<BlogDto>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string BlogName { get; set; }
    }


    public class BlogCreationCommandHandler : IRequestHandler<BlogCreationCommand, BlogDto>
    {
        private readonly CodeProdigeeContext _context;

        public BlogCreationCommandHandler(CodeProdigeeContext context)
        {
            _context = context;
        }

        public async Task<BlogDto> Handle(BlogCreationCommand request, CancellationToken cancellationToken)
        {
            BlogDto dto = new();
            try
            {
                if(request is not null && !string.IsNullOrEmpty(request.BlogName) 
                    && !string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Name))
                {
                    var targetBlog = new Models.Blog
                    {
                        AdminName = request.Name,
                        BlogName = request.BlogName,
                        BlogAdminEmail = request.Email
                    };

                    _context.Blogs.Add(targetBlog);
                    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    if(targetBlog.ID != Guid.Empty)
                    {
                        var queryCondition = await _context.Blogs.AnyAsync(x => x.ID.Equals(targetBlog.ID)).ConfigureAwait(false);
                        if (queryCondition == true)
                        {
                            dto = new BlogDto
                            {
                                AdminName = request.Name,
                                BlogAdminEmail = request.Email,
                                BlogName = request.BlogName,
                                BlogID = targetBlog.ID
                            };
                        }
                    }
                    return dto;
                }
                throw new InvalidOperationException("The blog didn't save and nothing was saved");
            }
            catch (Exception ex)
            {

                throw new Exception($"Illegal operation attempted! {ex.Message}");
            }
        }
    }
}
