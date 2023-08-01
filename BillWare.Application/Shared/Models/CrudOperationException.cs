public class CrudOperationException : Exception
{
    public CrudOperationException() : base()
    {
    }

    public CrudOperationException(string message) : base(message)
    {
    }

    public CrudOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
