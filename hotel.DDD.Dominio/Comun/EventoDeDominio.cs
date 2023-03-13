using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comun
{
    public class EventoDeDominio
    {
        public string Tipo;
        private string AgregadoId;
        private string Agregado;

        public EventoDeDominio(string tipo)
        {
            Tipo = tipo;
        }

        public string ObtenerAgregadoId()
        {
            return AgregadoId;
        }

        public string ObtenerAgregado()
        {
            return Agregado;
        }

        public void EstablecerAgregadoId(string agregadoId)
        {
            AgregadoId = agregadoId;
        }

        public void EstablecerAgregado(string agregado)
        {
            Agregado = agregado;
        }
    }
}
