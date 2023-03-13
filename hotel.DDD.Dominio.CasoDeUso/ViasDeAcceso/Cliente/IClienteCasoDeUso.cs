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
        Task RegistrarCliente(RegistrarClienteComando comando);
        Task AgregarPQR(AgregarPQRComando comando);
    }
}
