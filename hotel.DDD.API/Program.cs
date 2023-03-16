using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Habitacion;
using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Reserva;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Habitacion;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Reserva;
using hotel.DDD.Infraestructura;
using hotel.DDD.Infraestructura.Respositorios;
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
builder.Services.AddScoped<IHabitacionCasoDeUso, HabitacionCasoDeUso>();
builder.Services.AddScoped<IReservaCasoDeUso, ReservaCasoDeUso>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    context.Database.Migrate();
}

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