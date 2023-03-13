namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion
{
    public record TipoDeHabitacionId
    {
        public Guid Value { get; init; }

        public TipoDeHabitacionId(Guid value)
        {
            Value = value;
        }

        public static TipoDeHabitacionId Create(Guid value_)
        {
            return new TipoDeHabitacionId(value_);
        }

        public static implicit operator Guid(TipoDeHabitacionId tipoDeHabitacionId)
        {
            return tipoDeHabitacionId.Value;
        }
    }
}
