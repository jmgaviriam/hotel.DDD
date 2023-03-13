using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago
{
    public record TipoDeMedioDePago
    {
        public string Nombre { get; init; }
        public string Descripcion { get; init; }

        public TipoDeMedioDePago(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public static TipoDeMedioDePago Create(string nombre, string descripcion)
        {
            Guard.Against.NullOrEmpty(nombre, nameof(nombre), "El nombre no puede estar vacio");
            Guard.Against.NullOrEmpty(descripcion, nameof(descripcion), "La descripcion no puede estar vacia");

            return new TipoDeMedioDePago(nombre, descripcion);
        }
    }
}
