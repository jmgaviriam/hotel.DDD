using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Pruebas.Cliente.Constructores
{
    public class ConstructorDeAgregarPQR
    {
        public string ClienteId;
        public DateTime Fecha;
        public string Motivo;

        public ConstructorDeAgregarPQR ConClienteId(string clienteId)
        {
            ClienteId = clienteId;
            return this;
        }

        public ConstructorDeAgregarPQR ConFecha(DateTime fecha)
        {
            Fecha = fecha;
            return this;
        }

        public ConstructorDeAgregarPQR ConMotivo(string motivo)
        {
            Motivo = motivo;
            return this;
        }

        public AgregarPQRComando Construir()
        {
            return new AgregarPQRComando(ClienteId, Fecha, Motivo);
        }

    }
}
