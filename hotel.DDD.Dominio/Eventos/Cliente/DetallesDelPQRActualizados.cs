using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;
using hotel.DDD.Dominio.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class DetallesDelPQRActualizados : EventoDeDominio
    {
        public Guid PqrId { get; init; }
        public DetallesDelPQR DetallesDelPQR { get; init; }
        public DetallesDelPQRActualizados(Guid pqrId, DetallesDelPQR detallesDelPQR) : base("DetallesDelPQRActualizados")
        {
            PqrId = pqrId;
            DetallesDelPQR = detallesDelPQR;
        }
    }
}

