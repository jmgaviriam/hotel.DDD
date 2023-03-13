using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class TipoDeHabitacion
    {
        public Guid Id { get; set; }
        public Guid HabitacionId { get; init; }
        public virtual Habitacion Habitacion { get; private set; }
        public DetallesDeHabitacion DetallesDeHabitacion { get; private set; }

        public TipoDeHabitacion(Guid id, DetallesDeHabitacion detallesDeHabitacion)
        {
            this.Id = id;
            this.DetallesDeHabitacion = detallesDeHabitacion;
        }

    }
}
