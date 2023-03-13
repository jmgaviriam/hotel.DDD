namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR
{
    public record PQRId
    {
        public Guid value { get; init; }

        internal PQRId(Guid value_)
        {
            value = value_;
        }

        public static PQRId Create(Guid value_)
        {
            return new PQRId(value_);
        }

        public static implicit operator Guid(PQRId pQRId)
        {
            return pQRId.value;
        }
    }
}
