namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a Bad Request",
                401 => "You are Unauthorized to access!",
                404 => "Not Found",
                500 => "Error",
                _ => ""
            };
        }
    }
}
