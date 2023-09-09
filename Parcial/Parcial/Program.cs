using data;
using data.repositorio;
using data.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysqlConfig(builder.Configuration.GetConnectionString("mysqlConection"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClienteRepository, ClienteRepository>();
builder.Services.AddScoped<iEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<iVentaRepository, VentaRepository>();
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
