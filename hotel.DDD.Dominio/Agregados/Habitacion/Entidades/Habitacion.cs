using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class Habitacion
    {
        public Guid Id { get; set; }
        public NumeroDeHabitacion NumeroDeHabitacion { get; private set; }
        public EstadoDeLaHabitacion EstadoDeHabitacion { get; private set; }
        public Guid TipoDeHabitacionId { get; init; }
        public virtual TipoDeHabitacion TipoDeHabitacion { get; init; }
        public virtual List<Producto> Productos { get; private set; }

        public Habitacion(Guid id, NumeroDeHabitacion numeroDeHabitacion)
        {
            this.Id = id;
            this.NumeroDeHabitacion = numeroDeHabitacion;
        }


        public void SetEstadoDeHabitacion(EstadoDeLaHabitacion estadoDeHabitacion)
        {
            this.EstadoDeHabitacion = estadoDeHabitacion;
        }
    }
}
