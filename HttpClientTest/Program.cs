using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HttpClientTest.Data;
using System.Text;
using System.Net.Http.Headers;
using HttpClientTest.Controller;

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
    var secret = builder.Configuration.GetValue<string>("Secret");
    var key = builder.Configuration.GetValue<string>("Key");
    var encoded = EncoderClass.Base64Encode($"{key}:{secret}");

    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);
   /* c.DefaultRequestHeaders.Add("Authorization", "Basic " + Base64Encode($"{key}:{secret}")); */
});
builder.Services.AddHttpClient("departureBoardURL", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("GetDepartureBoard"));
    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddTransient<Timer.Services.TokenTimer>();

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});


app.Run();
