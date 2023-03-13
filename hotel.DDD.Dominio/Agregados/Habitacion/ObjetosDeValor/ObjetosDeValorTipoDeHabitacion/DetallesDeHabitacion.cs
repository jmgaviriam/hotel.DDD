using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion
{
    public record DetallesDeHabitacion
    {
        public string Categoria { get; init; }
        public int Capacidad { get; init; }
        public int PrecioPorNoche { get; init; }

        public DetallesDeHabitacion(string categoria, int capacidad, int precioPorNoche)
        {
            Categoria = categoria;
            Capacidad = capacidad;
            PrecioPorNoche = precioPorNoche;
        }

        public static DetallesDeHabitacion Create(string categoria_, int capacidad_, int precioPorNoche_)
        {
            Guard.Against.NullOrEmpty(categoria_, nameof(categoria_), "La categoria no puede estar vacia");
            Guard.Against.NegativeOrZero(capacidad_, nameof(capacidad_), "La capacidad no puede ser negativa o cero");
            Guard.Against.NegativeOrZero(precioPorNoche_, nameof(precioPorNoche_), "El precio por noche no puede ser negativo o cero");

            return new DetallesDeHabitacion(categoria_, capacidad_, precioPorNoche_);
        }
    }
}
