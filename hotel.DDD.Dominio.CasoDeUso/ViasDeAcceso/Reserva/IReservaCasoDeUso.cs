using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;
using hotel.DDD.Dominio.Comandos.Reserva;

namespace hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Reserva
{
    public interface IReservaCasoDeUso
    {
        Task<Agregados.Reserva.Entidades.Reserva> ObtenerReservaPorId(Guid reservaId);
        Task<Agregados.Reserva.Entidades.Reserva> CrearReserva(CrearReservaComando comando);
        Task<Agregados.Reserva.Entidades.Reserva> AsignarFuncionario(AsignarFuncionarioComando comando);
        Task<Agregados.Reserva.Entidades.Reserva> AsignarMedioDePago(AsignarMedioDePagoComando comando);
    }
}
