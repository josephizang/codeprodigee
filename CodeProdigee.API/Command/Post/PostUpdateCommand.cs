using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Post
{
    public class PostUpdateCommand : IRequest<PostProcessedDto>
    {
        public Guid PostID { get; set; }
        public bool PublishPost { get; set; }

        public string PostTitle { get; set; }

        public string PostBody { get; set; }

        public string NewTags { get; set; }

        public DateTime PostDate { get; set; }

        public Guid AuthorID { get; set; }

        public List<Guid> Tags { get; set; }

        public List<Guid> Resources { get; set; }

    }


    public class PostUpdateCommandHandler : IRequestHandler<PostUpdateCommand, PostProcessedDto>
    {
        private readonly IMediator _mediator;
        private readonly CodeProdigeeContext _context;

        public PostUpdateCommandHandler(IMediator mediator, CodeProdigeeContext context)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<PostProcessedDto> Handle(PostUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var targetPost = await _context.Posts.Where(p => p.ID == request.PostID)
                .SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                targetPost.PostTitle = request.PostTitle;
                targetPost.PostBody = request.PostBody;
                targetPost.PublishPost = request.PublishPost;
                var resources = request.Resources.Select(r => new Models.Resource { ID = r }).ToList();
                targetPost.Resources = resources;

                if (!string.IsNullOrEmpty(request.NewTags) && request.NewTags.Length > 2)
                {
                    targetPost.Tags = request.NewTags.Split(',').Select(n => new Tag { TagName = n }).ToList();
                }

                if (request.Tags.Any())
                {
                    request.Tags.ForEach(t => targetPost.Tags.Add(new Tag { ID = t }));
                }

                _context.Entry(targetPost).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return new PostProcessedDto { PostID = targetPost.ID };
            }
            catch (Exception)
            {
                throw;
            }            

        }
    }
}
