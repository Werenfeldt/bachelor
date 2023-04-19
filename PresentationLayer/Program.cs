using DomainLayer;
using ServiceLayer;
using RepositoryLayer;
using OpenAI.GPT3.Extensions;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddKeyPerFile("/run/secrets", optional: true);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<BachelorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BachelorDB")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IBachelorDbContext, BachelorDbContext>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepoManager, RepoManager>();
builder.Services.AddOpenAIService();
builder.Services.AddBlazoredSessionStorage();

var gitToken = builder.Configuration["APIToken:GithubIntegrationToken"];

var app = builder.Build();

app.MapGet("/createproject", () => gitToken);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BachelorDbContext>();
        dbContext.Database.Migrate();
    }
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
