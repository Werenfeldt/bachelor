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
builder.Services.AddOpenAIService().BuildServiceProvider().GetRequiredService<IOpenAIService>();

var app = builder.Build();

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
