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
    public class ReconstruccionDelCliente
    {
        public Cliente CrearAgregado(List<EventoDeDominio> eventos, ClienteId id)
        {
            Cliente cliente = new Cliente(id);
            eventos.ForEach(evento =>
            {
                switch (evento)
                {
                    case DatosPersonalesAgregados datosPersonalesAgregados:
                        cliente.SetDatosPersonalesAgregado(datosPersonalesAgregados.DatosPersonales);
                        break;
                    case DatosPersonalesActualizados datosPersonalesActualizados:
                        cliente.ActualizarDatosPersonalesAgregado(datosPersonalesActualizados.DatosPersonales);
                        break;
                    case PQRAgregado pQRAgregado:
                        cliente.AgregarPQRAgregado(pQRAgregado.PQR);
                        break;
                    case DetallesDelPQRAgregados detallesDelPQRAgregados:
                        cliente.AgregarDetallesDelPQRAgregado(detallesDelPQRAgregados.DetallesDelPQR);
                        break;
                    case DetallesDelPQRActualizados detallesDelPQRActualizados:
                        cliente.ActualizarDetallesDelPQRAgregado(detallesDelPQRActualizados.PqrId, detallesDelPQRActualizados.DetallesDelPQR);
                        break;
                }
            });
            return cliente;
        }
    }
}
