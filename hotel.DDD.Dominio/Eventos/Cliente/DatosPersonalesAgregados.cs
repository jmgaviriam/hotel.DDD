using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class DatosPersonalesAgregados : EventoDeDominio
    {
        public ClienteDatosPersonales DatosPersonales { get; set; }
        public DatosPersonalesAgregados(ClienteDatosPersonales datosPersonales) : base("DatosPersonalesAgregados")
        {
            DatosPersonales = datosPersonales;
        }
    }
}
