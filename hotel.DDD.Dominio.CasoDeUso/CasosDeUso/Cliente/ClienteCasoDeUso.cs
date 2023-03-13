using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Cliente.Entidades;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Cliente;
using hotel.DDD.Dominio.Generico;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorHistorialDeReservas;
using Newtonsoft.Json;

namespace hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Cliente
{
    internal class ClienteCasoDeUso : IClienteCasoDeUso
    {
        private readonly IRepositorioDeEventos<EventoGuardado> _repositorioDeEventos;

        public ClienteCasoDeUso(IRepositorioDeEventos<EventoGuardado> repositorioDeEventos)
        {
            _repositorioDeEventos = repositorioDeEventos;
        }

        public async Task RegistrarCliente(RegistrarClienteComando comando)
        {
            var cliente = new Agregados.Cliente.Entidades.Cliente(ClienteId.Create(Guid.NewGuid()));
            var datosPersonales = DatosPersonales.Create(
                comando.Nombre,
                comando.Apellido,
                comando.Correo,
                comando.Telefono
                );
            cliente.SetDatosPersonales(datosPersonales);
            List<EventoDeDominio> eventos = cliente.ObtenerCambios();
            await GuardarEventos(eventos);
        }

        public Task AgregarPQR(AgregarPQRComando comando)
        {
            throw new NotImplementedException();
        }

        //public async Task AgregarPQR(AgregarPQRComando comando)
        //{
        //    var cambiosCliente = new AplicadorDeCambiosDeCliente();
        //    var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ClienteId);
        //    var clienteId = ClienteId.Create(Guid.Parse(comando.ClienteId));
        //    var cliente = cambiosCliente.CrearAgregado(ListaDeEventos, clienteId);
        //}

        //private async Task<object> ObtenerEventosPorAgregadoId(string comandoClienteId)
        //{

        //}

        private async Task GuardarEventos(List<EventoDeDominio> eventos)
        {
            var ArregloDeEventos = eventos.ToArray();
            foreach (var evento in ArregloDeEventos)
            {
                var EventoGuardado = new EventoGuardado();
                EventoGuardado.IdGuardado = Guid.NewGuid().ToString();
                EventoGuardado.IdAgregado = evento.ObtenerAgregadoId();
                EventoGuardado.NombreGuardado = evento.ObtenerAgregado();//??

                switch (evento)
                {
                    case ClienteRegistrado clienteRegistrado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(clienteRegistrado);
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
                }
                await _repositorioDeEventos.AddAsync(EventoGuardado);
            }
            await _repositorioDeEventos.SaveChangesAsync();
        }
    }
}
