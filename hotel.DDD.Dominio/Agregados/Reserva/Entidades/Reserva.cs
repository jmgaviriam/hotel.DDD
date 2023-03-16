using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Reserva;

namespace hotel.DDD.Dominio.Agregados.Reserva.Entidades
{
    public class Reserva : EventoDeAgregado<ReservaId>
    {
        public ReservaId ReservaId { get; init; }
        public Fechas Fechas { get; private set; }

        public virtual Funcionario Funcionario { get; private set; }

        public virtual MedioDePago MedioDePago { get; private set; }

        public string ClienteId { get; set; }

        public string HabitacionId { get; set; }


        #region Metodos de la Reserva como gestor de eventos

        public Reserva(ReservaId reservaId) : base(reservaId)
        {
            this.ReservaId = reservaId;
        }

        public void setReservaId(ReservaId reservaReservaId)
        {
            AgregarEvento(new ReservaCreada(reservaReservaId.ToString()));
        }

        public void AgregarCliente(string clienteId)
        {
            AgregarEvento(new ClienteAgregado(clienteId));
        }

        public void AgregarHabitacion(string habitacionId)
        {
            AgregarEvento(new HabitacionAgregada(habitacionId));
        }

        public void AgregarFechas(Fechas fechas)
        {
            AgregarEvento(new FechasAgregadas(fechas));
        }

        public void AsignarFuncionario(Funcionario funcionario)
        {
            AgregarEvento(new FuncionarioAsignado(funcionario));
        }

        public void AgregarDatosFuncionario(FuncionarioDatosPersonales datosPersonalesFuncionario)
        {
            AgregarEvento(new DatosPersonalesDelFuncionarioAgregados(datosPersonalesFuncionario));
        }

        public void AsignarMedioDePago(MedioDePago medioDePago)
        {
            AgregarEvento(new MedioDePagoAsignado(medioDePago));
        }

        public void AgregarTipoDeMedioDePago(TipoDeMedioDePago tipoDeMedioDePago)
        {
            AgregarEvento(new TipoDeMedioDePagoAgregado(tipoDeMedioDePago));
        }
        #endregion

        #region Metodos de la Reserva como entidad
        public void AgregarFechasAgregado(Fechas fechas)
        {
            this.Fechas = fechas;
        }

        public void AsignarFuncionarioAgregado(Funcionario funcionario)
        {
            this.Funcionario = funcionario;
        }

        public void AgregarDatosPersonalesDelFuncionarioAgregado(FuncionarioDatosPersonales datosPersonales)
        {
            this.Funcionario.DatosPersonales = datosPersonales;
        }

        public void AsignarMedioDePagoAgregado(MedioDePago medioDePago)
        {
            this.MedioDePago = medioDePago;
        }

        public void AgregarTipoDeMedioDePagoAgregado(TipoDeMedioDePago tipoDeMedioDePago)
        {
            this.MedioDePago.TipoDeMedioDePago = tipoDeMedioDePago;
        }

        #endregion


        public void AgregarClienteAgregado(string clienteId)
        {
            this.ClienteId = clienteId;
        }

        public void AgregarHabitacionAgregado(string habitacionId)
        {
            this.HabitacionId = habitacionId;
        }
    }
}
