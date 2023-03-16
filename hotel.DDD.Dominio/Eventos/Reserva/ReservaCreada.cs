using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class ReservaCreada : EventoDeDominio

    {
        public string ReservaId { get; init; }
        public ReservaCreada(string ReservaId) : base("ReservaCreada")
        {
            this.ReservaId = ReservaId;
        }
    }
}
