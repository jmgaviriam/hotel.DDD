using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class ClienteAgregado : EventoDeDominio
    {
        public string ClienteId { get; init; }

        public ClienteAgregado(string ClienteId) : base("ClienteAgregado")
        {
            this.ClienteId = ClienteId;
        }
    }
}
