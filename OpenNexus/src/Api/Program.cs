using Arnkels.OpenNexus.Application;
using Arnkels.OpenNexus.Infrastructure;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy => policy.WithOrigins("https://localhost:7114", "http://localhost:5116")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType));
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();