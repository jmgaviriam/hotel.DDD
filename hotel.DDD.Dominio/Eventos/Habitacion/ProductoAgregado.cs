using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.Entidades;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Habitacion
{
    public class ProductoAgregado : EventoDeDominio
    {
        public Producto producto { get; init; }
        public ProductoAgregado(Producto Producto) : base("ProductoAgregado")
        {
            this.producto = Producto;
        }
    }
}
