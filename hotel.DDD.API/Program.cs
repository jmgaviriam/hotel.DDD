using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Infraestructura.Datos.DataBaseContext;
using hotel.DDD.Infraestructura.Datos.Respositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("urlConnection"),
    b => b.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)
));

builder.Services.AddScoped(typeof(IRepositorioDeEventos<>), typeof(RepositorioDeEventos<>));
builder.Services.AddScoped<IClienteCasoDeUso, ClienteCasoDeUso>();

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