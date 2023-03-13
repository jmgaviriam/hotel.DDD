using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Generico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotel.DDD.Infraestructura.Configuracion
{
    public class EventoGuardadoConfig : IEntityTypeConfiguration<EventoGuardado>
    {
        public void Configure(EntityTypeBuilder<EventoGuardado> builder)
        {
            builder.ToTable("EventoGuardado");
            builder.HasKey(x => x.IdGuardado);
        }
    }
}
