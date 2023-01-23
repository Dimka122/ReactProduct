using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proj.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the HTTP request pipeline.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactJSDomain",
        policy => policy.WithOrigins("http://localhost:44454")
        .AllowAnyHeader()
        .AllowAnyMethod());
});
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connstr")));

var app = builder.Build();
app.UseCors("ReactJSDomain");
app.UseAuthorization();
app.MapControllers();

app.Run();
