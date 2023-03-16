using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva
{
    public class ReservaId : Identidad
    {
        internal ReservaId(Guid id) : base(id) { }

        public static ReservaId Create(Guid id)
        {
            return new ReservaId(id);
        }
    }
}
