using EMS.Core;
using EMS.Infrastructure;
using EMS.Infrastructure.Presistence.Context;
using EMS.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//database
var connection = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(connection));


//Resolve Modules
builder.Services.AddInfrastructuresModules();
builder.Services.AddBusinessModules();
builder.Services.AddCoreModules();

// all servive must added before builder.Build();
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
