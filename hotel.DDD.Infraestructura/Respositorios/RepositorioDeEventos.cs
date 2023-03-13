using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.Generico;
using Microsoft.EntityFrameworkCore;

namespace hotel.DDD.Infraestructura.Datos.Respositorios
{
    public class RepositorioDeEventos<T> : RepositoryBase<T>, IRepositorioDeEventos<T> where T : class
    {
        private readonly DataBaseContext.DataBaseContext dataBaseContex;
        public RepositorioDeEventos(DataBaseContext.DataBaseContext dbContext) : base(dbContext)
        {
            dataBaseContex = dbContext;
        }

        public async Task<List<EventoGuardado>> ObtenerEventosPorAgregadoId(Guid agregadoId)
        {
            return await dataBaseContex.EventosGuardados.Where(x => x.IdAgregado == agregadoId.ToString()).ToListAsync();
        }
    }
}
