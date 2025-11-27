using MGTIM.Infrastructure.Persistence;
using MGTIM.Infrastructure.Persistence.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MTGIM.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbOptions>(
    builder.Configuration.GetSection(DbOptions.SectionName));

builder.Services.AddDbContext<ApplicationDbContext>(
    (serviceProvider, options) =>
    {
        var dbOptions = serviceProvider.GetRequiredService<IOptions<DbOptions>>().Value;
        
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("MTGIM"),
            sqlOptions =>
            {
                sqlOptions.CommandTimeout(dbOptions.CommandTimeoutInSeconds);
            });

        options.EnableDetailedErrors(dbOptions.EnableDetailedErrors);
        options.EnableSensitiveDataLogging(dbOptions.EnableSensitiveDataLogging);
    })
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
