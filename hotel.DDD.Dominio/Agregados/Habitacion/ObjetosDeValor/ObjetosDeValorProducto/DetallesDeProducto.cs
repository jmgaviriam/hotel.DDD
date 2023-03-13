using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto
{
    public record DetallesDeProducto
    {
        public string Nombre { get; init; }
        public string Descripcion { get; init; }
        public decimal Precio { get; init; }
        public int Cantidad { get; init; }

        public DetallesDeProducto(string nombre, string descripcion, decimal precio, int cantidad)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
        }

        public static DetallesDeProducto Create(string nombre, string descripcion, decimal precio, int cantidad)
        {
            Guard.Against.NullOrEmpty(nombre, nameof(nombre), "El nombre no puede estar vacio");
            Guard.Against.NullOrEmpty(descripcion, nameof(descripcion), "La descripcion no puede estar vacia");
            Guard.Against.NegativeOrZero(precio, nameof(precio), "El precio no puede ser negativo o cero");
            Guard.Against.NegativeOrZero(cantidad, nameof(cantidad), "La cantidad no puede ser negativa o cero");

            return new DetallesDeProducto(nombre, descripcion, precio, cantidad);
        }
    }
}
