using Microsoft.Extensions.Configuration;

namespace ServiceLayer.Tests;
public abstract class ContextSetup
{
    protected readonly IServiceManager _serviceManager;
    public ContextSetup()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        var builder = new DbContextOptionsBuilder<BachelorDbContext>();
        builder.UseSqlite(connection);
        var context = new BachelorDbContext(builder.Options);
        context.Database.EnsureCreated();


        string key = "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";

        var openAiService = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = key
        });

        var repoManager = new RepoManager(context);

        _serviceManager = new ServiceManager(repoManager, openAiService);
    }
}