namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago
{
    public record MedioDePagoId
    {
        public Guid value { get; init; }

        public MedioDePagoId(Guid value)
        {
            this.value = value;
        }

        public static MedioDePagoId Create(Guid value_)
        {
            return new MedioDePagoId(value_);
        }

        public static implicit operator Guid(MedioDePagoId medioDePagoId)
        {
            return medioDePagoId.value;
        }
    }
}
