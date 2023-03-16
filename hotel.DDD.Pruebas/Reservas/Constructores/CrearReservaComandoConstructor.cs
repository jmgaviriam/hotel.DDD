using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Dominio.Comandos.Reserva;

namespace hotel.DDD.Pruebas.Reserva.Constructores
{
    public class CrearReservaComandoConstructor
    {
        public string clienteId;
        public string habitacionId;
        public DateTime fechaReserva;
        public DateTime fechaIngreso;
        public DateTime fechaSalida;

        public CrearReservaComandoConstructor ConClienteId(string clienteId)
        {
            this.clienteId = clienteId;
            return this;
        }

        public CrearReservaComandoConstructor ConHabitacionId(string habitacionId)
        {
            this.habitacionId = habitacionId;
            return this;
        }

        public CrearReservaComandoConstructor ConFechaReserva(DateTime fechaReserva)
        {
            this.fechaReserva = fechaReserva;
            return this;
        }

        public CrearReservaComandoConstructor ConFechaIngreso(DateTime fechaIngreso)
        {
            this.fechaIngreso = fechaIngreso;
            return this;
        }

        public CrearReservaComandoConstructor ConFechaSalida(DateTime fechaSalida)
        {
            this.fechaSalida = fechaSalida;
            return this;
        }

        public CrearReservaComando Construir()
        {
            return new CrearReservaComando(clienteId, habitacionId, fechaReserva, fechaIngreso, fechaSalida);
        }
    }
}