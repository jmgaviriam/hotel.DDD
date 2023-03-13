using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Cliente
{
    public class AgregarPQRComando
    {
        public string ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }

        public AgregarPQRComando(string clienteId, DateTime fecha, string motivo)//es necesario?
        {
            ClienteId = clienteId;
            Fecha = fecha;
            Motivo = motivo;
        }

    }
}
