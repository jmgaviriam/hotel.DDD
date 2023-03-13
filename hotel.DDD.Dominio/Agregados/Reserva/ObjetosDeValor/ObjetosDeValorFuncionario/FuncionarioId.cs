namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario
{
    public record FuncionarioId
    {
        public Guid value { get; init; }

        internal FuncionarioId(Guid value_)
        {
            value = value_;
        }

        public static FuncionarioId Create(Guid value_)
        {
            return new FuncionarioId(value_);
        }

        public static implicit operator Guid(FuncionarioId funcionarioId)
        {
            return funcionarioId.value;
        }
    }
}
