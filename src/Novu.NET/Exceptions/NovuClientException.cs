namespace Novu.NET.Exceptions;

public class NovuClientException : Exception
{
    public NovuClientException()
    {
        
    }

    public NovuClientException(string message) : base(message)
    {
        
    }

    public NovuClientException(string message, Exception inner): base(message,  inner)
    {
        
    }
}