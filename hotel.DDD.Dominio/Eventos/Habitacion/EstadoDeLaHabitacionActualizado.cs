using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class EstadoDeLaHabitacionActualizado : EventoDeDominio
    {
        public bool Disponible = true;
        public EstadoDeLaHabitacionActualizado() : base("EstadoDeLaHabitacionActualizado")
        {
            this.Disponible = !this.Disponible;
        }
    }
}
