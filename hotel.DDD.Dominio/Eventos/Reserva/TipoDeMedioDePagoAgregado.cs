using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class TipoDeMedioDePagoAgregado : EventoDeDominio
    {
        public TipoDeMedioDePago TipoDeMedioDePago { get; init; }
        public TipoDeMedioDePagoAgregado(TipoDeMedioDePago tipoDeMedioDePago) : base("TipoDeMedioDePagoAgregado")
        {
            TipoDeMedioDePago = tipoDeMedioDePago;
        }

    }
}
