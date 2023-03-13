using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva
{
    public record Fechas
    {
        public DateTime FechaReserva { get; init; }
        public DateTime FechaIngreso { get; init; }
        public DateTime FechaSalida { get; init; }

        public Fechas(DateTime fechaReserva, DateTime fechaIngreso, DateTime fechaSalida)
        {
            FechaReserva = fechaReserva;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
        }

        public static Fechas Create(DateTime fechaReserva, DateTime fechaIngreso, DateTime fechaSalida)
        {
            Guard.Against.Default(fechaReserva, nameof(fechaReserva), "La fecha de reserva no puede ser por defecto");
            Guard.Against.Default(fechaIngreso, nameof(fechaIngreso), "La fecha de ingreso no puede ser por defecto");
            Guard.Against.Default(fechaSalida, nameof(fechaSalida), "La fecha de salida no puede ser por defecto");

            return new Fechas(fechaReserva, fechaIngreso, fechaSalida);
        }
    }
}
