namespace BillWare.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public IDictionary<string, string[]>? Details { get; set; }

        public CodeErrorException(int statusCode, 
                                  string? message = null,
                                  IDictionary<string, string[]>? details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public CodeErrorException(int statusCode, 
                                  string? message = null,
                                  string? stackTrace = null) : base(statusCode, message)
        {
            Details = new Dictionary<string, string[]>
            {
                { "StackTrace", new string[] { stackTrace ?? string.Empty } }
            };
        }
    }
}
