using Microsoft.AspNetCore.Mvc;
using OpenWeather.Domain.Interfaces;
using OpenWeather.Domain.Services;
using OpenWeather.Domain.Models.CurrentWeather;
using OpenWeather.Domain.Models.Forecast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IOpenWeatherService, OpenWeatherService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
