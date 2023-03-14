using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class DatosPersonalesActualizados : EventoDeDominio
    {
        public ClienteDatosPersonales DatosPersonales { get; set; }

        public DatosPersonalesActualizados(ClienteDatosPersonales datosPersonales) : base("DatosPersonalesActualizados")
        {
            DatosPersonales = datosPersonales;
        }
    }
}
