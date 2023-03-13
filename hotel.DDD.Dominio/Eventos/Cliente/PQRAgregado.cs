using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Agregados.Cliente.Entidades;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class PQRAgregado : EventoDeDominio
    {
        public PQR PQR { get; init; }
        public PQRAgregado(PQR PQR) : base("PQRAgregado")
        {
            this.PQR = PQR;
        }
    }
}
