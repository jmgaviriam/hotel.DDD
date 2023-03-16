using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Pruebas.Cliente.Constructores
{
    public class ConstructorDeAgregarProducto
    {
        public string ClienteId;
        public DateTime Fecha;
        public string Motivo;

        public ConstructorDeAgregarProducto ConClienteId(string clienteId)
        {
            ClienteId = clienteId;
            return this;
        }

        public ConstructorDeAgregarProducto ConFecha(DateTime fecha)
        {
            Fecha = fecha;
            return this;
        }

        public ConstructorDeAgregarProducto ConMotivo(string motivo)
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
