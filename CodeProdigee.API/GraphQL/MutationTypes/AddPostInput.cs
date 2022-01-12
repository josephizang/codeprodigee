using CodeProdigee.API.Models;
using System;

namespace CodeProdigee.API.GraphQL.MutationTypes
{
    public record AddPostInput(string postTitle, string postBody, DateTime postDate, string authorId);

    public record AddPostPayload(Post post);
}
