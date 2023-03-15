using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Habitacion
{
    public class AsignarTipoDeHabitacionComando
    {
        public string HabitacionId { get; set; }
        public string categoria { get; set; }
        public int capacidad { get; set; }
        public int precioPorNoche { get; set; }
    }
}
