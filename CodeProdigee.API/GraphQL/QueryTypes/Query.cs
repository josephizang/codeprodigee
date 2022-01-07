using CodeProdigee.API.Data;
using CodeProdigee.API.Models;
using HotChocolate.Data;
using System.Linq;

namespace CodeProdigee.API.GraphQL.QueryTypes
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts(CodeProdigeeContext context) => context.Posts;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments(CodeProdigeeContext context) => context.Comments;
    }
}
