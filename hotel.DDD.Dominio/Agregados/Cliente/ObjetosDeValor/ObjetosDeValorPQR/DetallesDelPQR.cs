using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR
{
    public record DetallesDelPQR
    {
        public DateTime Fecha { get; init; }
        public string Motivo { get; init; }

        public DetallesDelPQR(DateTime fecha, string motivo)
        {
            Fecha = fecha;
            Motivo = motivo;
        }

        public static DetallesDelPQR Create(DateTime fecha, string motivo)
        {
            Guard.Against.Default(fecha, nameof(fecha), "La fecha no puede ser la fecha por defecto");
            Guard.Against.NullOrEmpty(motivo, nameof(motivo), "El motivo no puede estar vacio");

            return new DetallesDelPQR(fecha, motivo);
        }
    }
}
