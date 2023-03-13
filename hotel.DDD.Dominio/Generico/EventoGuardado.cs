using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Generico
{
    public class EventoGuardado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdGuardado { get; set; }
        public string NombreGuardado { get; set; }
        public string IdAgregado { get; set; }
        public string CuerpoDelEvento { get; set; }
    }
}
