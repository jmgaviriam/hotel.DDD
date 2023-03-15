using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion
{
    public class HabitacionId : Identidad
    {
        internal HabitacionId(Guid id) : base(id) { }

        public static HabitacionId Create(Guid id)
        {
            return new HabitacionId(id);
        }
    }
}
