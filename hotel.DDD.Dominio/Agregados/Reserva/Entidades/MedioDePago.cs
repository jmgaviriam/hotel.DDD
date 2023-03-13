using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class MedioDePago
    {
        public Guid Id { get; private set; }
        public TipoDeMedioDePago TipoDeMedioDePago { get; private set; }
        public Guid ReservaId { get; init; }
        public virtual Reserva Reserva { get; private set; }

        public MedioDePago(Guid id, TipoDeMedioDePago tipoDeMedioDePago)
        {
            this.Id = id;
            this.TipoDeMedioDePago = tipoDeMedioDePago;
        }


    }
}
