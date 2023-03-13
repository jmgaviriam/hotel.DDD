using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorHistorialDeReservas;

namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class HistorialDeReservas
    {
        public Guid Id { get; init; }
        public DetallesDelHistorial DetallesDelHistorial { get; private set; }

        public Guid ClienteId { get; init; }
        public virtual Cliente Cliente { get; private set; }

        public HistorialDeReservas(Guid id, Guid clienteId)
        {
            this.Id = id;
            this.ClienteId = clienteId;
        }


        public void SetDetallesDelHistorial(DetallesDelHistorial detallesDelHistorial)
        {
            this.DetallesDelHistorial = detallesDelHistorial;
        }

    }
}
