using ECommerce.Persistence;
using ECommerce.Application;
using ECommerce.Application.Exceptions;
using Serilog;
using ECommerce.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using ECommerce.Domain.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Host.UseSerilog((context, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<PostgreDbContext>()
                .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.MapGet("users/me", async(ClaimsPrincipal claims, PostgreDbContext context) =>
{
    string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    return await context.Users.FindAsync(userId);
}).RequireAuthorization();

app.UseHttpsRedirection();
app.ExceptionMiddlewareConfigureHandler();
app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
