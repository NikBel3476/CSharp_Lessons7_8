namespace Exceptions;

public class MyException : Exception
{
    public int? ErrorCode { get; }
    
    public MyException()
    {
    }

    public MyException(string? message) : base(message)
    {
    }
    
    public MyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public MyException(string? message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}