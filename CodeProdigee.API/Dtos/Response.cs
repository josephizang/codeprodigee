using CodeProdigee.API.Abstractions;

namespace CodeProdigee.API.Dtos
{
    public class Response<T> : BaseResponse
    {

        public T Payload { get; set; } = default;

        public Response(T payload)
        {
            Payload = payload;
        }

        public Response(string errorMessage)
        {
            Message = errorMessage;
        }
    }
}
