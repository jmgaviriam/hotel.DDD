using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Cliente
{
    public class RegistrarClienteComando
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public RegistrarClienteComando(string nombre, string apellido, string correo, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
        }
    }
}
