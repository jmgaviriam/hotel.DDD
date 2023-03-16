using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Habitacion;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Dominio.Generico;
using hotel.DDD.Pruebas.Habitacion.Constructores;
using Moq;

namespace hotel.DDD.Pruebas.Habitacion.PruebasUnitarias
{
    public class HabitacionCasoDeUsoPrueba
    {
        private readonly Mock<IRepositorioDeEventos<EventoGuardado>> _mockRepositorioDeEventos;

        public HabitacionCasoDeUsoPrueba()
        {
            _mockRepositorioDeEventos = new();
        }

        [Fact]
        public async Task AsignarHabitacion()
        {
            //arrange
            _mockRepositorioDeEventos.Setup(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObtenerEventoGuardado());
            _mockRepositorioDeEventos.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //act
            var habitacionCasoDeUso = new HabitacionCasoDeUso(_mockRepositorioDeEventos.Object);
            var resultado = await habitacionCasoDeUso.AsignarHabitacion(ObtenerAsignarHabitacionComando());

            //assert
            _mockRepositorioDeEventos.Verify(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()), Times.Exactly(3));
            _mockRepositorioDeEventos.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AgregarProductoALaHabitacion()
        {
            //arrange
            _mockRepositorioDeEventos.Setup(x => x.ObtenerEventosPorAgregadoId(It.IsAny<string>()))
                .Returns(Task.FromResult(ObtenerListaDeEventosGuardados()));
            _mockRepositorioDeEventos.Setup(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObtenerEventoGuardado());

            _mockRepositorioDeEventos.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //act
            var habitacionCasoDeUso = new HabitacionCasoDeUso(_mockRepositorioDeEventos.Object);
            var resultado = await habitacionCasoDeUso.AgregarProducto(ObtenerComandoProducto());

            //assert
            _mockRepositorioDeEventos.Verify(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            _mockRepositorioDeEventos.Verify(x => x.ObtenerEventosPorAgregadoId(It.IsAny<string>()), Times.Exactly(2));
            _mockRepositorioDeEventos.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }


        private List<EventoGuardado> ObtenerListaDeEventosGuardados() =>
            new()
            {
                new ConstructorDeEventoGuardado()
                    .ConIdGuardado(1)
                    .ConNombreGuardado("NumeroDeHabitacionAsignado")
                    .ConIdAgregado("1")
                    .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Habitacion.NumeroDeHabitacionAsignado, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                    .Construir(),

                new ConstructorDeEventoGuardado()
                    .ConIdGuardado(1)
                    .ConNombreGuardado("EstadoDeLaHabitacionActualizado")
                    .ConIdAgregado("1")
                    .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Habitacion.EstadoDeLaHabitacionActualizado, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                    .Construir(),

                new ConstructorDeEventoGuardado()
                    .ConIdGuardado(1)
                    .ConNombreGuardado("HabitacionAsignada")
                    .ConIdAgregado("1")
                    .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Habitacion.HabitacionAsignada, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                    .Construir()
            };


        private AsignarHabitacionComando ObtenerAsignarHabitacionComando() =>
            new AsignarHabitacionComandoConstructor()
                .ConNumeroDeHabitacion(1)
                .Construir();



        private EventoGuardado ObtenerEventoGuardado() =>
            new ConstructorDeEventoGuardado()
                .ConIdGuardado(1)
                .ConNombreGuardado("HabitacionAsignada")
                .ConIdAgregado("1")
                .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Cliente.HabitacionAsignada, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                .Construir();

        private AgregarProductoComando ObtenerComandoProducto() =>
            new ConstructorDeAgregarProducto()
                .ConHabitacionId("7c9e6679-7425-40de-944b-e07fc1f90ae7")
                .ConNombre("Nombre")
                .ConDescripcion("Descripcion")
                .ConPrecio(10)
                .ConCantidad(10)
                .Construir();


    }
}
