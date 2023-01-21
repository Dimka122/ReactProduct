using Microsoft.EntityFrameworkCore;
using Proj.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the HTTP request pipeline.
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connstr")));

var app = builder.Build();
app.UseCors("corsapp");
app.UseAuthorization();
app.MapControllers();

app.Run();
