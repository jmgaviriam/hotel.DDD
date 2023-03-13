using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class DetallesDelPQRAgregados : EventoDeDominio
    {
        public DetallesDelPQR DetallesDelPQR { get; init; }
        public DetallesDelPQRAgregados(DetallesDelPQR detallesDelPQR) : base("DetallesDelPQRAgregados")
        {
            DetallesDelPQR = detallesDelPQR;
        }
    }
}
