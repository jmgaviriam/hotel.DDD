using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorHistorialDeReservas;

namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class HistorialDeReservas
    {
        public Guid Id { get; init; }

        public virtual List<Reserva.Entidades.Reserva> Reservas { get; private set; }

        //public DetallesDelHistorial DetallesDelHistorial { get; private set; }

        public HistorialDeReservas(Guid id)
        {
            this.Id = id;
        }

        //public void SetDetallesDelHistorial(DetallesDelHistorial detallesDelHistorial)
        //{
        //    this.DetallesDelHistorial = detallesDelHistorial;
        //}

    }
}
