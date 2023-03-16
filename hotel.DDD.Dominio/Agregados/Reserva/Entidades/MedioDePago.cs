using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class MedioDePago
    {
        public Guid Id { get; private set; }
        public TipoDeMedioDePago TipoDeMedioDePago { get; set; }

        public MedioDePago(Guid id)
        {
            this.Id = id;
        }

        public void SetTipoDeMedioDePago(TipoDeMedioDePago tipoDeMedioDePago)
        {
            this.TipoDeMedioDePago = tipoDeMedioDePago;
        }


    }
}
