using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comandos.Cliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;

namespace hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente
{
    public interface IClienteCasoDeUso
    {
        Task<Agregados.Cliente.Entidades.Cliente> ObtenerClientePorId(Guid id);
        Task<Agregados.Cliente.Entidades.Cliente> RegistrarCliente(RegistrarClienteComando comando);
        Task<Agregados.Cliente.Entidades.Cliente> ActualizarDatosPersonalesDelCliente(ActualizarClienteComando comando);
        Task<Agregados.Cliente.Entidades.Cliente> AgregarPQRAlCliente(AgregarPQRComando comando);
        Task<Agregados.Cliente.Entidades.Cliente> ActualizarPQRDelCliente(ActualizarDetallesDelPQRComando comando);
    }
}
