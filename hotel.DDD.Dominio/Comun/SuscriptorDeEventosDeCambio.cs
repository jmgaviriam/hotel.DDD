using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comun
{
    public class SuscriptorDeEventosDeCambio
    {
        private List<EventoDeDominio> Cambios = new List<EventoDeDominio>();

        public List<EventoDeDominio> ObtenerCambios()
        {
            return Cambios;
        }

        public void AgregarEvento(EventoDeDominio evento)
        {
            this.Cambios.Add(evento);
        }

    }
}
