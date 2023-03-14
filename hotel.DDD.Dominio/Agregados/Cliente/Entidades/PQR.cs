using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;


namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class PQR
    {
        public Guid Id { get; init; }
        public DetallesDelPQR DetallesDelPQR { get; private set; }

        public PQR(Guid id)
        {
            this.Id = id;
        }

        public void SetDetallesDelPQR(DetallesDelPQR detallesDelPQR)
        {
            this.DetallesDelPQR = detallesDelPQR;
        }

        public void ActualizarDetalles(DetallesDelPQR detallesDelPqr)
        {
            this.DetallesDelPQR = detallesDelPqr;
        }
    }
}
