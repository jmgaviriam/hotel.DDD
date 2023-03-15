using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class HabitacionAsignada : EventoDeDominio
    {
        public string HabitacionId { get; init; }
        public HabitacionAsignada(string habitacionId) : base("HabitacionAsignada")
        {
            this.HabitacionId = habitacionId;
        }
    }
}
