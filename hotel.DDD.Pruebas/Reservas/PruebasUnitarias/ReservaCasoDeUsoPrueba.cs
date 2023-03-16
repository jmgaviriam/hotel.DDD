using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Habitacion;
using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Reserva;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Dominio.Comandos.Reserva;
using hotel.DDD.Dominio.Generico;
using hotel.DDD.Pruebas.Habitacion.Constructores;
using hotel.DDD.Pruebas.Reserva.Constructores;
using Moq;

namespace hotel.DDD.Pruebas.Reservas.PruebasUnitarias
{
    public class ReservaCasoDeUsoPrueba
    {
        private readonly Mock<IRepositorioDeEventos<EventoGuardado>> _mockRepositorioDeEventos;

        public ReservaCasoDeUsoPrueba()
        {
            _mockRepositorioDeEventos = new();
        }

        [Fact]
        public async Task CrearReserva()
        {
            //arrange
            _mockRepositorioDeEventos.Setup(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObtenerEventoGuardado());
            _mockRepositorioDeEventos.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //act
            var ReservaCasoDeUso = new ReservaCasoDeUso(_mockRepositorioDeEventos.Object);
            var resultado = await ReservaCasoDeUso.CrearReserva(ObtenerCrearReservaComando());

            //assert
            _mockRepositorioDeEventos.Verify(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()), Times.Exactly(4));
            _mockRepositorioDeEventos.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        private CrearReservaComando ObtenerCrearReservaComando() =>
            new CrearReservaComandoConstructor()
                .ConClienteId("1")
                .ConHabitacionId("1")
                .ConFechaReserva(DateTime.Now)
                .ConFechaIngreso(DateTime.Now)
                .ConFechaSalida(DateTime.Now)
                .Construir();

        private EventoGuardado ObtenerEventoGuardado() =>
            new ConstructorDeEventoGuardado()
                .ConIdGuardado(1)
                .ConNombreGuardado("ReservaCreada")
                .ConIdAgregado("1")
                .ConCuerpoDelEvento("Cuerpo del evento")
                .Construir();
    }
}
