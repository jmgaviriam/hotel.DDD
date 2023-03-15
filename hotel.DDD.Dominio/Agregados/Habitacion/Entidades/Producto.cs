using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class Producto
    {
        public Guid Id { get; init; }
        public DetallesDeProducto DetallesDeProducto { get; private set; }

        public Producto(Guid id)
        {
            this.Id = id;
        }

        public void AgregarDetallesDeProducto(DetallesDeProducto detallesDeProducto)
        {
            this.DetallesDeProducto = detallesDeProducto;
        }

        public void ActualizarDetallesDeProducto(DetallesDeProducto detallesDeProducto)
        {
            this.DetallesDeProducto = detallesDeProducto;
        }
    }
}
