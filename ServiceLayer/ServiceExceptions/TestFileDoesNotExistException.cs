namespace ServiceLayer;
public class TestFileDoesNotExistException : Exception
{
    public TestFileDoesNotExistException()
    {
    }

    public TestFileDoesNotExistException(string message)
        : base(message)
    {
    }

    public TestFileDoesNotExistException(string message, Exception inner)
        : base(message, inner)
    {
    }
}