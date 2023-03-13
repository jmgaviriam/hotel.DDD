using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comun
{
    public abstract class EventoDeAgregado<T> : Entidad<T> where T : Identidad
    {
        private SuscriptorDeEventosDeCambio suscriptorDeEventosDeCambio = new SuscriptorDeEventosDeCambio();
        protected EventoDeAgregado(T entidadId) : base(entidadId)
        {
        }

        public List<EventoDeDominio> ObtenerCambios()
        {
            return suscriptorDeEventosDeCambio.ObtenerCambios().ToList();
        }

        public void AgregarEvento(EventoDeDominio evento)
        {
            string nameClass = evento.GetType().Name;
            evento.EstablecerAgregado(nameClass);
            evento.EstablecerAgregadoId(Identidad().Uuid.ToString());
            suscriptorDeEventosDeCambio.AgregarEvento(evento);
        }
    }
}
