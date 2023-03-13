using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class ClienteRegistrado : EventoDeDominio
    {
        public string ClienteId { get; init; }
        public ClienteRegistrado(string ClienteId) : base("ClienteRegistrado")
        {
            this.ClienteId = ClienteId;
        }
    }
}
