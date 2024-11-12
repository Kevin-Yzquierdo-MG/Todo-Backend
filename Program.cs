using Todolist.Data.Repository;
using Todolist.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Configurar la conexión a la base de datos MySQL
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("connection"),
                     new MySqlServerVersion(new Version(8, 0, 40))));

// Configura el repositorio
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Construir la aplicación
var app = builder.Build();

// Usar CORS
app.UseCors("AllowAngularOrigins");

// Configurar la tubería de solicitudes HTTP.
app.UseAuthorization();
app.MapControllers();

app.Run();
