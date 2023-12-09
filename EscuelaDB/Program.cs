using EscuelaDB.Models;
using EscuelaDB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<EscuelaDBDatabaseSettings>(
    builder.Configuration.GetSection("EscuelaDBDatabase"));

builder.Services.AddSingleton<ProfesoresService>();
builder.Services.AddSingleton<MateriasService>();
builder.Services.AddSingleton<AlumnosService>();
builder.Services.AddSingleton<CalificacionesService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
