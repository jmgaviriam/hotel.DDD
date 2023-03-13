using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion
{
    public record NumeroDeHabitacion
    {
        public int Numero { get; init; }

        public NumeroDeHabitacion(int numero)
        {
            Numero = numero;
        }

        public static NumeroDeHabitacion Create(int numero)
        {
            Guard.Against.NegativeOrZero(numero, nameof(numero), "El numero de habitacion no puede ser negativo o cero");
            return new NumeroDeHabitacion(numero);
        }

    }
}
