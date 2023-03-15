using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class TipoDeHabitacion
    {
        public Guid Id { get; init; }
        public DetallesDeHabitacion DetallesDeHabitacion { get; set; }

        public TipoDeHabitacion(Guid id)
        {
            this.Id = id;
        }

        public void SetDetallesDeHabitacion(DetallesDeHabitacion detallesDeHabitacion)
        {
            this.DetallesDeHabitacion = detallesDeHabitacion;
        }

    }
}
