using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario
{
    public record FuncionarioDatosPersonales
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        public string Telefono { get; init; }
        public string Correo { get; init; }

        public FuncionarioDatosPersonales(string nombre, string apellido, string telefono, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
        }

        public static FuncionarioDatosPersonales Create(string nombre, string apellido, string telefono, string correo)
        {
            Guard.Against.NullOrEmpty(nombre, nameof(nombre), "El nombre no puede estar vacio");
            Guard.Against.NullOrEmpty(apellido, nameof(apellido), "El apellido no puede estar vacio");
            Guard.Against.NullOrEmpty(telefono, nameof(telefono), "El telefono no puede estar vacio");
            Guard.Against.NullOrEmpty(correo, nameof(correo), "El correo no puede estar vacio");

            return new FuncionarioDatosPersonales(nombre, apellido, telefono, correo);
        }
    }
}
