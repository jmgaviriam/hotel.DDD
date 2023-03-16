using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class HabitacionAgregada : EventoDeDominio
    {
        public string HabitacionId { get; init; }

        public HabitacionAgregada(string HabitacionId) : base("HabitacionAgregada")
        {
            this.HabitacionId = HabitacionId;
        }
    }
}
