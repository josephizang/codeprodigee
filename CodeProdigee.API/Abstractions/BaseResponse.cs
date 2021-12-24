using System.Collections.Generic;

namespace CodeProdigee.API.Abstractions
{
    public abstract class BaseResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = false;

        public IEnumerable<string> Errors { get; set; }
    }
}
