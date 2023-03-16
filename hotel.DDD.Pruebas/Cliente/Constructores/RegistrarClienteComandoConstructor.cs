using hotel.DDD.Dominio.Comandos.Cliente;

namespace hotel.DDD.Pruebas.Cliente.Constructores
{
    public class RegistrarClienteComandoConstructor
    {
        public string Nombre;
        public string Apellido;
        public string Correo;
        public string Telefono;

        public RegistrarClienteComandoConstructor ConNombre(string nombre)
        {
            Nombre = nombre;
            return this;
        }

        public RegistrarClienteComandoConstructor ConApellido(string apellido)
        {
            Apellido = apellido;
            return this;
        }

        public RegistrarClienteComandoConstructor ConCorreo(string correo)
        {
            Correo = correo;
            return this;
        }

        public RegistrarClienteComandoConstructor ConTelefono(string telefono)
        {
            Telefono = telefono;
            return this;
        }

        public RegistrarClienteComando Construir()
        {
            return new RegistrarClienteComando(Nombre, Apellido, Correo, Telefono);
        }
    }
}