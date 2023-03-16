using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class FechasAgregadas : EventoDeDominio
    {
        public Fechas Fechas { get; set; }
        public FechasAgregadas(Fechas fechas) : base("FechasAgregadas")
        {
            Fechas = fechas;
        }
    }
}
