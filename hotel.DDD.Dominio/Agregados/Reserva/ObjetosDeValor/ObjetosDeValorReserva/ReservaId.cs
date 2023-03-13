namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva
{
    public record ReservaId
    {
        public Guid value { get; init; }

        public ReservaId(Guid value)
        {
            this.value = value;
        }

        public static ReservaId Create(Guid value_)
        {
            return new ReservaId(value_);
        }

        public static implicit operator Guid(ReservaId reservaId)
        {
            return reservaId.value;
        }
    }
}
