namespace Infrastructure.Models;

public class UserResult
{
    public int StatusCode { get; set; }
    public string? Error { get; set; }
}

public class UserObjectResult<T>(T? result) : UserResult
{
    public T? Result { get; set; } = result;
}