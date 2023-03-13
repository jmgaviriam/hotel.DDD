using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Cliente;

namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class AplicadorDeCambiosDeCliente
    {
        public Cliente CrearAgregado(List<EventoDeDominio> eventos, ClienteId id)
        {
            Cliente cliente = new Cliente(id);
            eventos.ForEach(evento =>
            {
                switch (evento)
                {
                    case DatosPersonalesActualizados datosPersonalesActualizados:
                        cliente.SetDatosPersonales(datosPersonalesActualizados.DatosPersonales);
                        break;
                    case PQRAgregado pQRAgregado:
                        cliente.AgregarPQR(pQRAgregado.PQR);
                        break;
                    case DetallesDelPQRAgregados detallesDelPQRAgregados:
                        cliente.AgregarDetallesDelPQR(detallesDelPQRAgregados.DetallesDelPQR);
                        break;
                }
            });
            return cliente;
        }
    }
}
