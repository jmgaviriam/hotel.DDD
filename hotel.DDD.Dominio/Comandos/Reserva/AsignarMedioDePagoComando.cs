using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Reserva
{
    public class AsignarMedioDePagoComando
    {
        public string ReservaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
