using Infrastature;
using Infrastature.dbcontext;
using Microsoft.EntityFrameworkCore;
using Application;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructuerservices();
builder.Services.ApplicationServices();

// Add services to the container.
builder.Services.AddDbContext<CURDDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
