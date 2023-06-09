﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Habitacion
{
    public class ActualizarDetallesDelProductoComando
    {
        public string HabitacionId { get; set; }
        public string ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
