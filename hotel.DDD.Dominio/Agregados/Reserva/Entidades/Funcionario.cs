using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class Funcionario
    {
        public Guid Id { get; private set; }
        public FuncionarioDatosPersonales DatosPersonales { get; set; }
        //public List<Reserva> Reservas { get; private set; }

        public Funcionario(Guid id)
        {
            this.Id = id;
        }

        public void SetDatosPersonalesDelFuncionario(FuncionarioDatosPersonales funcionarioDatosPersonales)
        {
            this.DatosPersonales = funcionarioDatosPersonales;
        }
    }
}
