using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente
{
    public class ClienteId : Identidad
    {
        public Guid value { get; init; }

        internal ClienteId(Guid value_) : base(value_)
        {
            value = value_;
        }

        public static ClienteId Create(Guid value_)
        {
            return new ClienteId(value_);
        }

        public static implicit operator Guid(ClienteId clienteId)
        {
            return clienteId.value;
        }
    }
}
