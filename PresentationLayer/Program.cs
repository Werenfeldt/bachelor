using DomainLayer;
using ServiceLayer;
using RepositoryLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMudServices();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepoManager, RepoManager>();
builder.Services.AddOpenAIService();

builder.Services.AddDbContext<BachelorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BachelorDB")));
// TODO remember to delete or use
//Save for later
//builder.Services.AddOpenAIService().BuildServiceProvider().GetRequiredService<IOpenAIService>();

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
