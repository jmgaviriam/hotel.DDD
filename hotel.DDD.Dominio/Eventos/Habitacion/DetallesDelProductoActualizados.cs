using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class DetallesDelProductoActualizados : EventoDeDominio
    {
        public Guid ProductoId { get; init; }
        public DetallesDeProducto DetallesDeProducto { get; init; }
        public DetallesDelProductoActualizados(Guid productoId, DetallesDeProducto detallesDeProducto) : base("DetallesDelProductoActualizados")
        {
            this.ProductoId = productoId;
            this.DetallesDeProducto = detallesDeProducto;
        }
    }
}
