using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class DatosPersonalesDelFuncionarioAgregados : EventoDeDominio
    {
        public FuncionarioDatosPersonales DatosPersonales { get; init; }
        public DatosPersonalesDelFuncionarioAgregados(FuncionarioDatosPersonales datosPersonales) : base("DatosPersonalesDelFuncionarioAgregados")
        {
            DatosPersonales = datosPersonales;
        }

    }
}
