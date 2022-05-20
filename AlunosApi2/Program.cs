using AlunosApi2.Context;
using AlunosApi2.Controllers;
using AlunosApi2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAlunoService, AlunosService>();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer("Data Source=BV2150581\\SQLEXPRESS;Initial Catalog=Estudos_ASPNET_REACT;Integrated Security=True"));

//builder.Services.AddHttpContextAccessor();


   

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
