using hotel.DDD.Dominio.Agregados.Cliente.Entidades;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;
using hotel.DDD.Dominio.Agregados.Reserva.Entidades;

namespace hotel.DDD.Dominio.Agregados.Cliente.Repositorios
{
    public interface IRepositorioCliente
    {
        Task<Entidades.Cliente> CrearCliente(Entidades.Cliente cliente);
        Task ActualizarDatosPersonales(Guid clienteId, DatosPersonales nuevosDatosPersonales);
        Task AgregarPQR(Guid clienteId, PQR pqr);
        Task ActualizarDetallesDelPQR(Guid clienteId, Guid pqrId, DetallesDelPQR nuevosDetalles);
        Task AgregarHistorialDeReservas(Guid clienteId, Reserva.Entidades.Reserva reserva);//No se si es necesario porque el historial de reservas se crea cuando se crean los detalles del historial
        Task ActualizarDetallesDelHistorial(Guid clienteId, Guid reservaId, string nuevosDetalles);
        Task AgregarReservaAlHistorial(Guid clienteId, Reserva.Entidades.Reserva reserva);
    }
}
