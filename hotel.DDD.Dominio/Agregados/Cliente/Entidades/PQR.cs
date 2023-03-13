using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;


namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class PQR
    {
        public Guid Id { get; init; }
        public DetallesDelPQR DetallesDelPQR { get; private set; }

        public Guid ClienteId { get; init; }
        public virtual Cliente Cliente { get; private set; }

        public PQR(Guid id, Guid clienteId)
        {
            this.Id = id;
            this.ClienteId = clienteId;
        }

        public void SetDetallesDelPQR(DetallesDelPQR detallesDelPQR)
        {
            this.DetallesDelPQR = detallesDelPQR;
        }
    }
}
