using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Reserva
{
    public class CrearReservaComando
    {
        public string ClienteId { get; set; }
        public string HabitacionId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }

        public CrearReservaComando(string clienteId, string habitacionId, DateTime fechaReserva, DateTime fechaIngreso, DateTime fechaSalida)
        {
            ClienteId = clienteId;
            HabitacionId = habitacionId;
            FechaReserva = fechaReserva;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
        }
    }
}
