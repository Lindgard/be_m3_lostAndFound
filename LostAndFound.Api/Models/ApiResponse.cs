namespace LostAndFound.Api.Models;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiResponse{T}"/> class.
    /// </summary>
    /// <param name="data">The data of the response.</param>
    /// <param name="message">The message of the response.</param>
    /// <param name="statusCode">The status code of the response.</param>
    public ApiResponse(T? data, string message, int statusCode)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
    }
}