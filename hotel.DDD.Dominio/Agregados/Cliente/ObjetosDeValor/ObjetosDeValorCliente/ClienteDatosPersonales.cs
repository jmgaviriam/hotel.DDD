using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente
{
    public record ClienteDatosPersonales
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public string Correo { get; init; }
        public string Telefono { get; init; }

        public ClienteDatosPersonales(string nombre, string apellido, string correo, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
        }

        public static ClienteDatosPersonales Create(string nombre, string apellido, string correo, string telefono)
        {

            Guard.Against.NullOrEmpty(nombre, nameof(nombre), "El nombre no puede estar vacio");
            Guard.Against.NullOrEmpty(apellido, nameof(apellido), "El apellido no puede estar vacio");
            Guard.Against.NullOrEmpty(correo, nameof(correo), "El correo no puede estar vacio");
            Guard.Against.NullOrEmpty(telefono, nameof(telefono), "El telefono no puede estar vacio");


            return new ClienteDatosPersonales(nombre, apellido, correo, telefono);
        }
    }
}
