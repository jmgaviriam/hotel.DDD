using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class DetallesDeHabitacionAgregados : EventoDeDominio
    {
        public DetallesDeHabitacion detallesDeHabitacion { get; init; }
        public DetallesDeHabitacionAgregados(DetallesDeHabitacion detallesDeHabitacion) : base("DetallesDeHabitacionAgregados")
        {
            this.detallesDeHabitacion = detallesDeHabitacion;
        }

    }
}
