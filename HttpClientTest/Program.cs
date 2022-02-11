using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HttpClientTest.Data;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("meta", c =>
{
    // reference "MetaAPI" in out appsettings.json for every request method to use as base web adress
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("MetaAPI"));
});
builder.Services.AddHttpClient("vast", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("GetVastToken"));
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(builder.Configuration.GetValue<string>("Secret"));
});

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
