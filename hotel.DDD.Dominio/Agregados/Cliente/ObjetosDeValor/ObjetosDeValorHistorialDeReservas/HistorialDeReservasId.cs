namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorHistorialDeReservas
{
    public record HistorialDeReservasId
    {
        public Guid value { get; init; }

        internal HistorialDeReservasId(Guid value_)
        {
            value = value_;
        }


        public static HistorialDeReservasId Create(Guid value_)
        {
            return new HistorialDeReservasId(value_);
        }

        public static implicit operator Guid(HistorialDeReservasId historialDeReservasId)
        {
            return historialDeReservasId.value;
        }
    }
}
