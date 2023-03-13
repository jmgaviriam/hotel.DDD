using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;

namespace hotel.DDD.Dominio.Eventos.Cliente
{
    public class DatosPersonalesActualizados : EventoDeDominio
    {
        public DatosPersonales DatosPersonales { get; set; }
        public DatosPersonalesActualizados(DatosPersonales datosPersonales) : base("DatosPersonalesActualizados")
        {
            DatosPersonales = datosPersonales;
        }
    }
}
