using CodeProdigee.API.Dtos;
using CodeProdigee.API.Dtos.Comments;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Comments
{
    public class GetAllCommentsByPostId : IRequest<CollectionResponse<CommentDto>>
    {
    }

    public class GetAllCommentsByPostIdHandler : IRequestHandler<GetAllCommentsByPostId, CollectionResponse<CommentDto>>
    {
        public Task<CollectionResponse<CommentDto>> Handle(GetAllCommentsByPostId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
