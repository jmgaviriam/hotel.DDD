using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Dominio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Pruebas.Habitacion.Constructores
{
    public class ConstructorDeAsignarFuncionario
    {
        public string HabitacionId;
        public string Nombre;
        public string Descripcion;
        public Decimal Precio;
        public int Cantidad;

        public ConstructorDeAsignarFuncionario ConHabitacionId(string habitacionId)
        {
            HabitacionId = habitacionId;
            return this;
        }

        public ConstructorDeAsignarFuncionario ConNombre(string nombre)
        {
            Nombre = nombre;
            return this;
        }

        public ConstructorDeAsignarFuncionario ConDescripcion(string descripcion)
        {
            Descripcion = descripcion;
            return this;
        }

        public ConstructorDeAsignarFuncionario ConPrecio(Decimal precio)
        {
            Precio = precio;
            return this;
        }

        public ConstructorDeAsignarFuncionario ConCantidad(int cantidad)
        {
            Cantidad = cantidad;
            return this;
        }

        public AgregarProductoComando Construir()
        {
            return new AgregarProductoComando(HabitacionId, Nombre, Descripcion, Precio, Cantidad);
        }

    }
}
