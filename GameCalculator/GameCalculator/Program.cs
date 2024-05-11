using GameCalculator.Data;
using GameCalculatorLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//default
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//game connection
var connectionGameString = builder.Configuration.GetConnectionString("GachaGameCalculator");

//code for db connection to default connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//For GameCalculatorLibrary
builder.Services.GachaGameCalculatorDependencies(options => options.UseSqlServer(connectionGameString));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
