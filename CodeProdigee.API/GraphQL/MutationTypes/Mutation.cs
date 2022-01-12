using CodeProdigee.API.Data;
using CodeProdigee.API.Models;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Threading.Tasks;

namespace CodeProdigee.API.GraphQL.MutationTypes
{
    public class Mutation
    {
        [UseDbContext(typeof(CodeProdigeeContext))]
        public async Task<AddPostPayload> CreatePost(AddPostInput input,
            [ScopedService] CodeProdigeeContext context)
        {
            if (input is null) throw new ArgumentNullException("Expected values have not been provided!");
            var post = new Post
            {
                AuthorID = input.authorId,
                PostBody = input.postBody,
                PostDate = input.postDate,
                PostTitle = input.postTitle,
                Comments = new(),
                PostAuthor = new(),
                PostReactions = new(),
                Resources = new(),
                Tags = new(),
            };
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return new AddPostPayload(post);
        }
    }
}
