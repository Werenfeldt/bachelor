using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using Presentation.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddOpenAIService().BuildServiceProvider().GetRequiredService<IOpenAIService>();
//builder.Services.AddSingleton<IOpenAIService>();

var app = builder.Build();
// var serviceCollection = new ServiceCollection();
// serviceCollection.AddScoped(_ => app);

// serviceCollection.AddOpenAIService();

// var serviceProvider = serviceCollection.BuildServiceProvider();
// var sdk = serviceProvider.GetRequiredService<IOpenAIService>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
