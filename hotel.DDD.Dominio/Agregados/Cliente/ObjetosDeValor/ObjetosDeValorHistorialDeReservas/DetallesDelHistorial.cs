using Ardalis.GuardClauses;

namespace hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorHistorialDeReservas
{
    public record DetallesDelHistorial
    {
        private List<Reserva.Entidades.Reserva> _reservas;

        public IReadOnlyCollection<Reserva.Entidades.Reserva> Reservas => _reservas.AsReadOnly();

        public Guid ReservaId { get; init; }
        public virtual Reserva.Entidades.Reserva Reserva { get; private set; }

        private DetallesDelHistorial(List<Reserva.Entidades.Reserva> reservas_)
        {
            _reservas = reservas_ ?? new List<Reserva.Entidades.Reserva>();
        }

        public static DetallesDelHistorial Create(List<Reserva.Entidades.Reserva> reservas_)
        {
            Guard.Against.Null(reservas_, nameof(reservas_), "El historial no puede estar vacio");

            return new DetallesDelHistorial(reservas_);
        }

    }

}
