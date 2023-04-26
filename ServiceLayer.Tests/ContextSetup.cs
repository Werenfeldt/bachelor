using Microsoft.Extensions.Configuration;

namespace ServiceLayer.Tests;
public abstract class ContextSetup
{
    protected readonly IServiceManager _serviceManager;
    protected readonly string? _defaultGitKey;
    protected readonly string? _testRepoGitKey;

    public ContextSetup()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<BachelorDbContext>();
        builder.UseSqlite(connection);

        var context = new BachelorDbContext(builder.Options);
        context.Database.EnsureCreated();



        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddUserSecrets<ContextSetup>();
        var configuration = configBuilder.Build();

        string? key = Environment.GetEnvironmentVariable("OpenAIServiceOptions");
        _defaultGitKey = Environment.GetEnvironmentVariable("GithubIntegrationToken");
        _testRepoGitKey = Environment.GetEnvironmentVariable("GithubTestToken");

        if (key == null || _defaultGitKey == null || _testRepoGitKey == null)
        {
            key = configuration.GetValue<string>("OpenAIServiceOptions:ApiKey");
            _defaultGitKey = configuration.GetValue<string>("APIToken:GithubIntegrationToken");
            _testRepoGitKey = configuration.GetValue<string>("APIToken:GithubTestToken");
            Console.WriteLine("hej");
        }

        var openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = key
        });

        var repoManager = new RepoManager(context);

        _serviceManager = new ServiceManager(repoManager, openAiService);
    }
}