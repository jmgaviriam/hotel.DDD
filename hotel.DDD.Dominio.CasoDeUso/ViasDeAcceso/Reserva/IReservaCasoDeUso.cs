using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Reserva
{
    public interface IReservaCasoDeUso
    {
        Task<Agregados.Reserva.Entidades.Reserva> ObtenerReservaPorId(int id);
        Task<Agregados.Reserva.Entidades.Reserva> CrearReserva(Agregados.Reserva.Entidades.Reserva reserva);

    }
}
