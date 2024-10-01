using Microsoft.EntityFrameworkCore;
using BackTurnos.Servicio;
using WebApiTurnos.Models;
using BackTurnos.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<DbCici2Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración del Repositorio
builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
builder.Services.AddScoped<IPeluqueriaServicio, PeluqueriaServicio>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();


// Otros servicios y configuraciones builder.Services.AddControllers();


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
