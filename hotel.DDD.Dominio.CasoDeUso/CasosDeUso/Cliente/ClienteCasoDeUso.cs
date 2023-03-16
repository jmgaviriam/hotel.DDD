using hotel.DDD.Dominio.Agregados.Cliente.Entidades;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Cliente;
using hotel.DDD.Dominio.Generico;
using Newtonsoft.Json;

namespace hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Cliente
{
    public class ClienteCasoDeUso : IClienteCasoDeUso
    {
        private readonly IRepositorioDeEventos<EventoGuardado> _repositorioDeEventos;

        public ClienteCasoDeUso(IRepositorioDeEventos<EventoGuardado> repositorioDeEventos)
        {
            _repositorioDeEventos = repositorioDeEventos;
        }

        public async Task<Agregados.Cliente.Entidades.Cliente> ObtenerClientePorId(Guid clienteId)
        {
            var reconstruccionDelCliente = new ReconstruccionDelCliente();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(clienteId.
                ToString());
            var clienteID = ClienteId.Create(clienteId);
            var cliente = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteID);

            return cliente;
        }

        public async Task<Agregados.Cliente.Entidades.Cliente> RegistrarCliente(RegistrarClienteComando comando)
        {
            var cliente = new Agregados.Cliente.Entidades.Cliente(ClienteId.Create(Guid.NewGuid()));
            cliente.setClienteId(cliente.ClienteId);
            var datosPersonales = ClienteDatosPersonales.Create(
                comando.Nombre,
                comando.Apellido,
                comando.Correo,
                comando.Telefono
                );
            cliente.SetDatosPersonales(datosPersonales);
            List<EventoDeDominio> eventosDeDominio = cliente.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            var reconstruccionDelCliente = new ReconstruccionDelCliente();
            cliente = reconstruccionDelCliente.CrearAgregado(eventosDeDominio, cliente.ClienteId);
            return cliente;
        }

        public async Task<Agregados.Cliente.Entidades.Cliente> ActualizarDatosPersonalesDelCliente(
            ActualizarClienteComando comando)
        {
            var reconstruccionDelCliente = new ReconstruccionDelCliente();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            var clienteId = ClienteId.Create(Guid.Parse(comando.ClienteId));
            var clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteId);
            var datosPersonales = ClienteDatosPersonales.Create(
                comando.Nombre,
                comando.Apellido,
                comando.Correo,
                comando.Telefono
            );
            clienteReconstruido.ActualizarDatosPersonales(datosPersonales);
            List<EventoDeDominio> eventosDeDominio = clienteReconstruido.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            reconstruccionDelCliente = new ReconstruccionDelCliente();
            ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteReconstruido.ClienteId);
            return clienteReconstruido;
        }

        public async Task<Agregados.Cliente.Entidades.Cliente> AgregarPQRAlCliente(AgregarPQRComando comando)
        {
            var reconstruccionDelCliente = new ReconstruccionDelCliente();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            var clienteId = ClienteId.Create(Guid.Parse(comando.ClienteId));
            var clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteId);

            var pqr = new PQR(PQRId.Create(Guid.NewGuid()));
            var detallesDelPQR = DetallesDelPQR.Create(
                comando.Fecha,
                comando.Motivo);

            clienteReconstruido.AgregarPQR(pqr);
            clienteReconstruido.AgregarDetallesDelPQR(detallesDelPQR);
            List<EventoDeDominio> eventos = clienteReconstruido.ObtenerCambios();
            await GuardarEventos(eventos);

            reconstruccionDelCliente = new ReconstruccionDelCliente();
            ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteId);
            return clienteReconstruido;
        }

        public async Task<Agregados.Cliente.Entidades.Cliente> ActualizarPQRDelCliente(ActualizarDetallesDelPQRComando comando)
        {
            var reconstruccionDelCliente = new ReconstruccionDelCliente();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            var clienteId = ClienteId.Create(Guid.Parse(comando.ClienteId));
            var clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteId);

            var detallesDelPQR = DetallesDelPQR.Create(
                comando.Fecha,
                comando.Motivo);

            clienteReconstruido.ActualizarDetallesDelPQR(Guid.Parse(comando.PQRId), detallesDelPQR);
            List<EventoDeDominio> eventos = clienteReconstruido.ObtenerCambios();
            await GuardarEventos(eventos);

            reconstruccionDelCliente = new ReconstruccionDelCliente();
            ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
            clienteReconstruido = reconstruccionDelCliente.CrearAgregado(ListaDeEventos, clienteId);
            return clienteReconstruido;
        }

        private async Task<List<EventoDeDominio>> ObtenerEventosPorAgregadoId(string comandoClienteId)
        {
            var listadoDeEventos = await _repositorioDeEventos.ObtenerEventosPorAgregadoId(comandoClienteId);
            if (listadoDeEventos == null)

                throw new Exception("No se encontraron eventos asociados a ese Id");

            return listadoDeEventos.Select(ev =>
            {
                string nombre = $"hotel.DDD.Dominio.Eventos.Cliente.{ev.NombreGuardado}, hotel.DDD.Dominio";
                Type tipo = Type.GetType(nombre);
                EventoDeDominio evento = (EventoDeDominio)JsonConvert.DeserializeObject(ev.CuerpoDelEvento, tipo);
                return evento;
            }).ToList();
        }

        private async Task GuardarEventos(List<EventoDeDominio> eventos)
        {
            var ArregloDeEventos = eventos.ToArray();
            for (var index = 0; index < ArregloDeEventos.Length; index++)
            {
                var EventoGuardado = new EventoGuardado();
                //EventoGuardado.IdGuardado = Guid.NewGuid().ToString();
                EventoGuardado.IdAgregado = ArregloDeEventos[index].ObtenerAgregadoId();
                EventoGuardado.NombreGuardado = ArregloDeEventos[index].ObtenerAgregado();//??

                switch (ArregloDeEventos[index])
                {
                    case ClienteRegistrado clienteRegistrado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(clienteRegistrado);
                        break;
                    case DatosPersonalesAgregados datosPersonalesAgregados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(datosPersonalesAgregados);
                        break;
                    case DatosPersonalesActualizados datosPersonalesActualizados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(datosPersonalesActualizados);
                        break;
                    case PQRAgregado pQRAgregado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(pQRAgregado);
                        break;
                    case DetallesDelPQRAgregados detallesDelPQRAgregados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(detallesDelPQRAgregados);
                        break;
                    case DetallesDelPQRActualizados detallesDelPQRActualizados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(detallesDelPQRActualizados);
                        break;
                }
                await _repositorioDeEventos.AddAsync(EventoGuardado);
            }
            await _repositorioDeEventos.SaveChangesAsync();
        }
    }
}
