using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.Entidades;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class TipoDeHabitacionAsignado : EventoDeDominio
    {
        public TipoDeHabitacion tipoDeHabitacion;

        public TipoDeHabitacionAsignado(TipoDeHabitacion tipoDeHabitacion) : base("TipoDeHabitacionAsignado")
        {
            this.tipoDeHabitacion = tipoDeHabitacion;
        }
    }
}
