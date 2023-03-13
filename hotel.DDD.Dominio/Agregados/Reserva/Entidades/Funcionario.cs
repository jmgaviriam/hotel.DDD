﻿using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class Funcionario
    {
        public Guid Id { get; private set; }
        public DatosPersonales DatosPersonales { get; private set; }
        public List<Reserva> Reservas { get; private set; }

        public Funcionario(Guid id, DatosPersonales datosPersonales)
        {
            this.Id = id;
            this.DatosPersonales = datosPersonales;
        }

    }
}
