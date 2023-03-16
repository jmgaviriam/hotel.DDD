using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Habitacion
{
    public class AgregarProductoComando
    {
        public string HabitacionId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public AgregarProductoComando(string habitacionId, string nombre, string descripcion, Decimal precio, int cantidad)
        {
            HabitacionId = habitacionId;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
