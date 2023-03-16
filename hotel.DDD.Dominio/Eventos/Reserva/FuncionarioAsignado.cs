using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Reserva.Entidades;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Eventos.Reserva
{
    public class FuncionarioAsignado : EventoDeDominio
    {
        public Funcionario Funcionario { get; init; }

        public FuncionarioAsignado(Funcionario Funcionario) : base("FuncionarioAsignado")
        {
            this.Funcionario = Funcionario;
        }
    }
}
