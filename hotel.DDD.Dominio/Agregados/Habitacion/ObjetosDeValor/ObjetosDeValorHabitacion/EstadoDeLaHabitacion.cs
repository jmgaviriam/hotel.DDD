using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion
{
    public record EstadoDeLaHabitacion
    {
        public bool Disponible { get; init; }

        public EstadoDeLaHabitacion(bool disponible)
        {
            Disponible = disponible;
        }

        public static EstadoDeLaHabitacion Create(bool disponible)
        {
            Guard.Against.Null(disponible, nameof(disponible), "El estado de la habitacion no puede ser nulo");

            return new EstadoDeLaHabitacion(disponible);
        }
    }
}
