using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class Reserva
    {
        public Guid Id { get; init; }
        public Fechas Fechas { get; private set; }

        public Guid FuncionarioId { get; init; }
        public virtual Funcionario Funcionario { get; private set; }

        public Guid MedioDePagoId { get; init; }
        public virtual MedioDePago MedioDePago { get; private set; }

        public Guid ClienteId { get; init; }
        public virtual Cliente.Entidades.Cliente Cliente { get; private set; }

        public Guid HabitacionId { get; init; }
        public virtual Habitacion.Entidades.Habitacion Habitacion { get; private set; }

        public Guid HistorialDeReservaId { get; init; }//?
        public virtual Cliente.Entidades.HistorialDeReservas HistorialDeReservas { get; private set; }//?

        public Reserva(Guid id, Guid clienteId, Guid habitacionId)
        {
            this.Id = id;
            this.ClienteId = clienteId;
            this.HabitacionId = habitacionId;
        }

        public void SetFuncionario(Funcionario funcionario)
        {
            this.Funcionario = funcionario;
        }

        public void SetMedioDePago(MedioDePago medioDePago)
        {
            this.MedioDePago = medioDePago;
        }

        public void SetFechas(Fechas fechas)
        {
            this.Fechas = fechas;
        }

    }
}
