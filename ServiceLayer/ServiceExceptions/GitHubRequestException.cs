namespace ServiceLayer;
public class GitHubRequestException : Exception
{
    public GitHubRequestException()
    {
    }

    public GitHubRequestException(string message)
        : base(message)
    {
    }

    public GitHubRequestException(string message, Exception inner)
        : base(message, inner)
    {
    }
}