using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class DetallesDeProductoAgregados : EventoDeDominio
    {
        public DetallesDeProducto detallesDeProducto { get; init; }
        public DetallesDeProductoAgregados(DetallesDeProducto detallesDeProducto) : base("DetallesDeProductoAgregado")
        {
            this.detallesDeProducto = detallesDeProducto;
        }
    }
}
