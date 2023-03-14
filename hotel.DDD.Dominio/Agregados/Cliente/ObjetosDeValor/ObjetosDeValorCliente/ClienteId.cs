using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente
{
    public class ClienteId : Identidad
    {

        internal ClienteId(Guid id) : base(id) { }

        public static ClienteId Create(Guid id)
        {
            return new ClienteId(id);
        }

    }
}
