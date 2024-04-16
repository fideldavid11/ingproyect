using back.Models;
using back.Repository.Abstract;
using back.Repository.Implementation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Agrega servicios a nuestro contenedor de servicios.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtiene la configuración de la aplicación.
var configuration = builder.Configuration;

// Configuración de la cadena de conexión a la base de datos.
var connectionString = configuration.GetConnectionString("DefaultConnection");


// Agrega el DbContext con la cadena de conexión.
builder.Services.AddDbContext<CeduladbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<ICedulaRepository, CedulaRepository>();
builder.Services.AddTransient<IFileService, FileService>(); // Agrega esta línea

builder.Services.AddCors(options =>
{
    options.AddPolicy("Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Politica");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
