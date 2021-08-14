using CodeProdigee.API.Data;
using CodeProdigee.API.Models;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Dtos.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeProdigee.API.EventNotifications.Posts;

namespace CodeProdigee.API.Command.Post
{
    public class PostCreateCommand : IRequest<PostProcessedDto>
    {
        public string PostTitle { get; set; }

        public string PostBody { get; set; }

        public string PostTags { get; set; }

        public bool Publish { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorName { get; set; }

        public List<ResourceDto> PostResources { get; set; } = new();
    }

    public class PostCreateCommandHandler : IRequestHandler<PostCreateCommand, PostProcessedDto>
    {
        private readonly CodeProdigeeContext _context;
        private readonly IMediator _mediator;

        public PostCreateCommandHandler(CodeProdigeeContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<PostProcessedDto> Handle(PostCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _context.Authors.Where(a => a.AuthorEmail.Equals(request.AuthorEmail))
                    .SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);

                var rawTags = request.PostTags.Split(',');
                var count = 0;
                var tags = new List<Tag>();
                while (count <= rawTags.Length - 1)
                {
                    tags.Add(new Tag { TagName = rawTags[count] });
                    count++;
                }

                var post = new Models.Post
                {
                    PostTitle = request.PostTitle,
                    PostBody = request.PostBody,
                    PostAuthor = author,
                    PublishPost = request.Publish,
                    AuthorID = author.ID,
                    Tags = tags
                };
                post.Resources = request.PostResources.Select(r => new Models.Resource
                {
                    ResourceUrl = r.ResourceUrl,
                    PostResourceType = r.Type
                }).ToList();

                if (post.PublishPost == true)
                    post.PublishDate = DateTimeOffset.UtcNow;

                _context.Posts.Add(post);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                var notification = await _context.Posts.AsNoTracking()
                                      .Include(p => p.PostAuthor)
                                      .Where(p => p.ID == post.ID)
                                      .Select(p => new PostCreatedNotification
                                      {
                                          AuthorName = p.PostAuthor.AuthorName,
                                          PostTitle = p.PostTitle,
                                          PublishedAt = p.PublishDate,
                                          ResourceLink = p.Resources.FirstOrDefault().ResourceUrl
                                      }).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
                await _mediator.Publish<PostCreatedNotification>(notification).ConfigureAwait(false);
                return new PostProcessedDto { PostID = post.ID };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
