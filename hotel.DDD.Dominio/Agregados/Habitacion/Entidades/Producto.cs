using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class Producto
    {
        public Guid Id { get; set; }
        public DetallesDeProducto DetallesDeProducto { get; private set; }
        public Guid HabitacionId { get; init; }
        public virtual Habitacion Habitacion { get; private set; }

        public Producto(Guid id, DetallesDeProducto detallesDeProducto)
        {
            this.Id = id;
            this.DetallesDeProducto = detallesDeProducto;
        }
    }
}
