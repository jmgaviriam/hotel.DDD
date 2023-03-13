namespace hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion
{
    public record HabitacionId
    {
        public Guid value { get; init; }

        public HabitacionId(Guid value)
        {
            this.value = value;
        }

        public static HabitacionId Create(Guid value_)
        {
            return new HabitacionId(value_);
        }

        public static implicit operator Guid(HabitacionId habitacionId)
        {
            return habitacionId.value;
        }


    }
}
