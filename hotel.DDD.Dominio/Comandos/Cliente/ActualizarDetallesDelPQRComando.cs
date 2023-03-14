using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Cliente
{
    public class ActualizarDetallesDelPQRComando
    {
        public string ClienteId { get; set; }
        public string PQRId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }

    }
}
