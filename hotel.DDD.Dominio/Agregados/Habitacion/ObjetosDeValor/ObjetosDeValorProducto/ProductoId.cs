namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto
{
    public record ProductoId
    {
        public Guid Value { get; init; }

        public ProductoId(Guid value)
        {
            Value = value;
        }

        public static ProductoId Create(Guid value_)
        {
            return new ProductoId(value_);
        }

        public static implicit operator Guid(ProductoId productoId)
        {
            return productoId.Value;
        }
    }
}
