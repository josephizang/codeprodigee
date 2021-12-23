using CodeProdigee.API.Data;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.EventNotifications.Posts;
using CodeProdigee.API.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        private readonly UserManager<ApplicationUser> _userManager;

        public PostCreateCommandHandler(CodeProdigeeContext context, IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mediator = mediator;
            _userManager = userManager;
        }
        public async Task<PostProcessedDto> Handle(PostCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _userManager.FindByEmailAsync(request.AuthorEmail).ConfigureAwait(false);

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
                    AuthorID = author.Id,
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
                                          AuthorFirstName = p.PostAuthor.FirstName,
                                          AuthorLastName = p.PostAuthor.LastName,
                                          AuthorId = p.PostAuthor.Id,
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
