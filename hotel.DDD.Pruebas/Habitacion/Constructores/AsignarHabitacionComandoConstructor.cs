using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Pruebas.Reserva.Constructores;

namespace hotel.DDD.Pruebas.Habitacion.Constructores
{
    public class AsignarHabitacionComandoConstructor
    {
        public int NumeroDeHabitacion;

        public AsignarHabitacionComandoConstructor ConNumeroDeHabitacion(int numeroDeHabitacion)
        {
            NumeroDeHabitacion = numeroDeHabitacion;
            return this;
        }

        public AsignarHabitacionComando Construir()
        {
            return new AsignarHabitacionComando(NumeroDeHabitacion);
        }
    }
}