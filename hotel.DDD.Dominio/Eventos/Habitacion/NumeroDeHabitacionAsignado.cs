using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class NumeroDeHabitacionAsignado : EventoDeDominio
    {
        public NumeroDeHabitacion numeroDeHabitacion;
        public NumeroDeHabitacionAsignado(NumeroDeHabitacion numeroDeHabitacion) : base("NumeroDeHabitacionAsignado")
        {
            this.numeroDeHabitacion = numeroDeHabitacion;
        }
    }
}
