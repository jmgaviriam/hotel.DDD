using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Generico
{
    public class EventoGuardado
    {
        public string IdGuardado { get; set; }
        public string NombreGuardado { get; set; }
        public string IdAgregado { get; set; }
        public string CuerpoDelEvento { get; set; }
    }
}
