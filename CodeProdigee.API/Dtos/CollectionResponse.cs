using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Dtos
{
    public class CollectionResponse<T> : BaseResponse where T : class
    {
        public IEnumerable<T> Payload { get; set; }

        public CollectionResponse(ICollection<T> payload)
        {
            Payload = payload;
        }

        public CollectionResponse(ICollection<T> payload, string message, bool successValue)
        {
            Payload = payload;
            Message = message;
            Success = successValue;
        }

        public CollectionResponse(ICollection<string> errors, string message)
        {
            Errors = errors;
            Message = message;
        }
    }
}
