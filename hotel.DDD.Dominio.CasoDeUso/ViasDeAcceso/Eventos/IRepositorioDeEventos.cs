using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using hotel.DDD.Dominio.Generico;

namespace hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos
{
    public interface IRepositorioDeEventos<T> : IRepositoryBase<T> where T : class
    {
        Task<List<EventoGuardado>> ObtenerEventosPorAgregadoId(string agregadoId);//EventoGuardo va en la capa de infraestructura
    }
}
