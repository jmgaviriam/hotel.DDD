using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Reserva.Entidades;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Reserva;
using hotel.DDD.Dominio.Comandos.Reserva;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Reserva;
using hotel.DDD.Dominio.Generico;
using Newtonsoft.Json;

namespace hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Reserva
{
    public class ReservaCasoDeUso : IReservaCasoDeUso
    {

        private readonly IRepositorioDeEventos<EventoGuardado> _repositorioDeEventos;

        public ReservaCasoDeUso(IRepositorioDeEventos<EventoGuardado> repositorioDeEventos)
        {
            _repositorioDeEventos = repositorioDeEventos;
        }

        public async Task<Agregados.Reserva.Entidades.Reserva> ObtenerReservaPorId(Guid reservaId)
        {
            var reconstruccionDeLaReserva = new ReconstruccionDeLaReserva();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(reservaId.ToString());
            var reservaID = ReservaId.Create(reservaId);
            var reserva = reconstruccionDeLaReserva.CrearAgregado(ListaDeEventos, reservaID);

            return reserva;
        }

        public async Task<Agregados.Reserva.Entidades.Reserva> CrearReserva(CrearReservaComando comando)
        {
            var reserva = new Agregados.Reserva.Entidades.Reserva(ReservaId.Create(Guid.NewGuid()));
            reserva.setReservaId(reserva.ReservaId);

            var clienteId = comando.ClienteId;
            reserva.AgregarCliente(clienteId);

            var habitacionId = comando.HabitacionId;
            reserva.AgregarHabitacion(habitacionId);

            var fechas = Fechas.Create(
                comando.FechaReserva,
                comando.FechaIngreso,
                comando.FechaSalida
                );
            reserva.AgregarFechas(fechas);
            List<EventoDeDominio> eventosDeDominio = reserva.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            var reconstruccionDeLaReserva = new ReconstruccionDeLaReserva();
            reserva = reconstruccionDeLaReserva.CrearAgregado(eventosDeDominio, reserva.ReservaId);
            return reserva;
        }


        public async Task<Agregados.Reserva.Entidades.Reserva> AsignarFuncionario(AsignarFuncionarioComando comando)
        {
            var reconstrucccionDeLaReserva = new ReconstruccionDeLaReserva();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ReservaId.ToString());
            var reservaID = ReservaId.Create(Guid.Parse(comando.ReservaId));
            var reservaReconstruida = reconstrucccionDeLaReserva.CrearAgregado(ListaDeEventos, reservaID);

            var funcionario = new Funcionario(FuncionarioId.Create(Guid.NewGuid()));
            var datosFuncionario = FuncionarioDatosPersonales.Create(
                comando.Nombre,
                comando.Apellido,
                comando.Telefono,
                comando.Correo
                );

            reservaReconstruida.AsignarFuncionario(funcionario);
            reservaReconstruida.AgregarDatosFuncionario(datosFuncionario);
            List<EventoDeDominio> eventos = reservaReconstruida.ObtenerCambios();
            await GuardarEventos(eventos);

            reconstrucccionDeLaReserva = new ReconstruccionDeLaReserva();
            ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ReservaId);
            reservaReconstruida = reconstrucccionDeLaReserva.CrearAgregado(ListaDeEventos, reservaID);
            return reservaReconstruida;
        }

        public async Task<Agregados.Reserva.Entidades.Reserva> AsignarMedioDePago(AsignarMedioDePagoComando comando)
        {
            var reconstrucccionDeLaReserva = new ReconstruccionDeLaReserva();
            var ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ReservaId.ToString());
            var reservaID = ReservaId.Create(Guid.Parse(comando.ReservaId));
            var reservaReconstruida = reconstrucccionDeLaReserva.CrearAgregado(ListaDeEventos, reservaID);

            var medioDePago = new MedioDePago(MedioDePagoId.Create(Guid.NewGuid()));
            var datosMedioDePago = TipoDeMedioDePago.Create(
                comando.Nombre,
                comando.Descripcion
                );

            reservaReconstruida.AsignarMedioDePago(medioDePago);
            reservaReconstruida.AgregarTipoDeMedioDePago(datosMedioDePago);
            List<EventoDeDominio> eventos = reservaReconstruida.ObtenerCambios();
            await GuardarEventos(eventos);

            reconstrucccionDeLaReserva = new ReconstruccionDeLaReserva();
            ListaDeEventos = await ObtenerEventosPorAgregadoId(comando.ReservaId);
            reservaReconstruida = reconstrucccionDeLaReserva.CrearAgregado(ListaDeEventos, reservaID);
            return reservaReconstruida;
        }


        private async Task<List<EventoDeDominio>> ObtenerEventosPorAgregadoId(string comandoReservaId)
        {
            var listadoDeEventos = await _repositorioDeEventos.ObtenerEventosPorAgregadoId(comandoReservaId);
            if (listadoDeEventos == null)

                throw new Exception("No se encontraron eventos asociados a ese Id");

            return listadoDeEventos.Select(ev =>
            {
                string nombre = $"hotel.DDD.Dominio.Eventos.Reserva.{ev.NombreGuardado}, hotel.DDD.Dominio";
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
                EventoGuardado.IdAgregado = ArregloDeEventos[index].ObtenerAgregadoId();
                EventoGuardado.NombreGuardado = ArregloDeEventos[index].ObtenerAgregado();//??

                switch (ArregloDeEventos[index])
                {
                    case ReservaCreada reservaCreada:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(reservaCreada);
                        break;
                    case ClienteAgregado clienteAgregado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(clienteAgregado);
                        break;
                    case HabitacionAgregada habitacionAgregada:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(habitacionAgregada);
                        break;
                    case FechasAgregadas fechasAgregadas:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(fechasAgregadas);
                        break;
                    case FuncionarioAsignado funcionarioAsignado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(funcionarioAsignado);
                        break;
                    case DatosPersonalesDelFuncionarioAgregados datosFuncionarioAgregados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(datosFuncionarioAgregados);
                        break;
                    case MedioDePagoAsignado medioDePagoAsignado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(medioDePagoAsignado);
                        break;
                    case TipoDeMedioDePagoAgregado tipoDeMedioDePagoAgregado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(tipoDeMedioDePagoAgregado);
                        break;
                }
                await _repositorioDeEventos.AddAsync(EventoGuardado);
            }
            await _repositorioDeEventos.SaveChangesAsync();
        }

    }
}
