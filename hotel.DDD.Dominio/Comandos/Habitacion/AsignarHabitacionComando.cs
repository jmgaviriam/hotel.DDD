﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel.DDD.Dominio.Comandos.Habitacion
{
    public class AsignarHabitacionComando
    {
        public int NumeroDeHabitacion { get; set; }

        public AsignarHabitacionComando(int numeroDeHabitacion)
        {
            NumeroDeHabitacion = numeroDeHabitacion;
        }
    }
}
