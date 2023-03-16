using hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Generico;
using hotel.DDD.Pruebas.Cliente.Constructores;
using Moq;

namespace hotel.DDD.Pruebas.Cliente.PruebasUnitarias
{
    public class HabitacionCasoDeUsoPrueba
    {
        private readonly Mock<IRepositorioDeEventos<EventoGuardado>> _mockRepositorioDeEventos;

        public HabitacionCasoDeUsoPrueba()
        {
            _mockRepositorioDeEventos = new();
        }

        [Fact]
        public async Task RegistrarCliente()
        {
            //arrange
            _mockRepositorioDeEventos.Setup(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObtenerEventoGuardado());

            _mockRepositorioDeEventos.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //act
            var clienteCasoDeUso = new ClienteCasoDeUso(_mockRepositorioDeEventos.Object);
            await clienteCasoDeUso.RegistrarCliente(ObtenerComandoDeCliente());

            //assert
            _mockRepositorioDeEventos.Verify(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()), Times.Exactly(2));
            _mockRepositorioDeEventos.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(1));
        }

        [Fact]
        public async Task AgregarPQRAlCliente()
        {
            //arrange
            _mockRepositorioDeEventos.Setup(x => x.ObtenerEventosPorAgregadoId(It.IsAny<string>()))
                .Returns(Task.FromResult(ObtenerListaDeEventosGuardados()));

            _mockRepositorioDeEventos.Setup(x => x.AddAsync(It.IsAny<EventoGuardado>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ObtenerEventoGuardado());

            _mockRepositorioDeEventos.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(200));

            //act
            var clienteCasoDeUso = new ClienteCasoDeUso(_mockRepositorioDeEventos.Object);
            await clienteCasoDeUso.AgregarPQRAlCliente(ObtenerComandoDePQR());

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
                    .ConNombreGuardado("DatosPersonalesAgregados")
                    .ConIdAgregado("1")
                    .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Cliente.DatosPersonalesAgregados, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                    .Construir(),

                new ConstructorDeEventoGuardado()
                    .ConIdGuardado(1)
                    .ConNombreGuardado("ClienteRegistrado")
                    .ConIdAgregado("1")
                    .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Cliente.ClienteResgistrado, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                    .Construir()
            };

        private RegistrarClienteComando ObtenerComandoDeCliente() =>
            new RegistrarClienteComandoConstructor()
                .ConNombre("Nombre")
                .ConApellido("Apellido")
                .ConCorreo("Correo")
                .ConTelefono("Telefono")
                .Construir();

        private EventoGuardado ObtenerEventoGuardado() =>
            new ConstructorDeEventoGuardado()
                .ConIdGuardado(1)
                .ConNombreGuardado("ClienteRegistrado")
                .ConIdAgregado("1")
                .ConCuerpoDelEvento("{\"Type\":\"hotel.DDD.Dominio.Eventos.Cliente.ClienteRegistrado, hotel.DDD.Dominio\",\"Data\":{\"Nombre\":\"Nombre\",\"Apellido\":\"Apellido\",\"Correo\":\"Correo\",\"Telefono\":\"Telefono\"}}")
                .Construir();

        private AgregarPQRComando ObtenerComandoDePQR() =>
            new ConstructorDeAgregarProducto()
                .ConClienteId("7c9e6679-7425-40de-944b-e07fc1f90ae7")
                .ConFecha(DateTime.Now)
                .ConMotivo("Motivo")
                .Construir();



    }
}
