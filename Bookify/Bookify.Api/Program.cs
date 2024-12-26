using Bookify.Api.Extensions;
using Bookify.Application;
using Bookify.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.MapScalarApiReference();
    app.ApplyMigrations();
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.MapControllers();

await app.RunAsync();
