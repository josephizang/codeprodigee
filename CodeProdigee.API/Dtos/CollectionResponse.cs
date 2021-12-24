using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Dtos
{
    public class CollectionResponse<T> : BaseResponse where T : class
    {
        public T Payload { get; set; }

        public CollectionResponse(T payload)
        {
            Payload = payload;
        }

        public CollectionResponse(T payload, string message, bool successValue)
        {
            Payload = payload;
            Message = message;
            Success = successValue;
        }

        public CollectionResponse(List<string> errors, string message)
        {
            Errors = errors;
            Message = message;
        }
    }
}
