﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.Entidades;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class MedioDePagoAsignado : EventoDeDominio
    {
        public MedioDePago MedioDePago { get; init; }
        public MedioDePagoAsignado(MedioDePago MedioDePago) : base("MedioDePagoAsignado")
        {
            this.MedioDePago = MedioDePago;
        }
    }
}
