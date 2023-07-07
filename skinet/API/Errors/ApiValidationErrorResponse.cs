namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors = null;
        public ApiValidationErrorResponse() : base(400)
        {
        }
    }
}
