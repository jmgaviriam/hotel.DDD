using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel.DDD.Dominio.Generico
{
    public class EventoGuardado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGuardado { get; set; }
        public string NombreGuardado { get; set; }
        public string IdAgregado { get; set; }
        public string CuerpoDelEvento { get; set; }

        public EventoGuardado(int idGuardado, string nombreGuardado, string idAgregado, string cuerpoDelEvento)
        {
            IdGuardado = idGuardado;
            NombreGuardado = nombreGuardado;
            IdAgregado = idAgregado;
            CuerpoDelEvento = cuerpoDelEvento;
        }

        public EventoGuardado()
        {
        }
    }
}
