using hotel.DDD.Dominio.Agregados.Reserva.Entidades;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorFuncionario;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorMedioDePago;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;

namespace hotel.DDD.Dominio.Agregados.Reserva.Repositorios
{
    internal interface IRepositorioReserva
    {
        Task<Entidades.Reserva> CrearReserva(Entidades.Reserva reserva);
        Task ActualizarFechas(Guid reservaId, Fechas fechas);
        Task AgregarFuncionario(Guid reservaId, Funcionario funcionario);
        Task AgregarMedioDePago(Guid reservaId, MedioDePago medioDePago);
        Task ActualizarDatosPersonales(Guid funcionarioId, FuncionarioDatosPersonales datosPersonales);
        Task ActualizarTipoDeMedioDePago(Guid medioDePagoId, TipoDeMedioDePago tipoDeMedioDePago);
    }
}
