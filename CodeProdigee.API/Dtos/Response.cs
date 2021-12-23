namespace CodeProdigee.API.Dtos
{
    public class Response<T> where T : class
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = false;

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
