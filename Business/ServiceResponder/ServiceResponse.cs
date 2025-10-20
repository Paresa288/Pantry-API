namespace Business.ServiceResponder
{
    /// <summary>
    /// Generic wrapper for web api response.       
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } 
        public int StatusCode { get; set; } 
        public List<string> ErrorMessages { get; set; }

        public static ServiceResponse<T> _Success(T data, int statusCode)
        {
            return new ServiceResponse<T> 
            { 
                Success = true, 
                Data = data, 
                StatusCode = statusCode 
            };
        }
        public static ServiceResponse<T> Fail(string message, int statusCode)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
            };
            
        }

    }
}
