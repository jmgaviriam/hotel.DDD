using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comun
{
    public class Identidad
    {
        public Guid Uuid { get; private set; }

        public Identidad(Guid uuid)
        {
            if (uuid == Guid.Empty)
            {
                throw new ArgumentException("El identificador no puede ser vacío");
            }

            this.Uuid = uuid;
        }
    }
}
