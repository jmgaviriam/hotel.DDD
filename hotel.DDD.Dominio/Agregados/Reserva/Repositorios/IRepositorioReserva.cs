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
        Task AgregarFuncionario(Guid reservaId, Funcionario funcionario);//Al parecer no se usa en el código porque el funcionario se crea en el constructor de la entidad Funcionario
        Task AgregarMedioDePago(Guid reservaId, MedioDePago medioDePago);//Al parecer no se usa en el código porque el medio de pago se crea en el constructor de la entidad MedioDePago
        Task ActualizarDatosPersonales(Guid funcionarioId, DatosPersonales datosPersonales);
        Task ActualizarTipoDeMedioDePago(Guid medioDePagoId, TipoDeMedioDePago tipoDeMedioDePago);
    }
}
