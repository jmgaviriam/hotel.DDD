using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Reserva;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class ReconstruccionDeLaReserva
    {
        public Reserva CrearAgregado(List<EventoDeDominio> eventos, ReservaId id)
        {
            Reserva reserva = new Reserva(id);
            eventos.ForEach(evento =>
            {
                switch (evento)
                {
                    case ClienteAgregado clienteAgregado:
                        reserva.AgregarClienteAgregado(clienteAgregado.ClienteId);
                        break;
                    case HabitacionAgregada habitacionAgregada:
                        reserva.AgregarHabitacionAgregado(habitacionAgregada.HabitacionId);
                        break;
                    case FechasAgregadas fechasAgregadas:
                        reserva.AgregarFechasAgregado(fechasAgregadas.Fechas);
                        break;
                    case FuncionarioAsignado funcionarioAsignado:
                        reserva.AsignarFuncionarioAgregado(funcionarioAsignado.Funcionario);
                        break;
                    case DatosPersonalesDelFuncionarioAgregados datosPersonalesDelFuncionarioAgregados:
                        reserva.AgregarDatosPersonalesDelFuncionarioAgregado(datosPersonalesDelFuncionarioAgregados.DatosPersonales);
                        break;
                    case MedioDePagoAsignado medioDePagoAsignado:
                        reserva.AsignarMedioDePagoAgregado(medioDePagoAsignado.MedioDePago);
                        break;
                    case TipoDeMedioDePagoAgregado tipoDeMedioDePagoAgregado:
                        reserva.AgregarTipoDeMedioDePagoAgregado(tipoDeMedioDePagoAgregado.TipoDeMedioDePago);
                        break;
                }
            });
            return reserva;
        }


    }
}
