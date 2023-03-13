using hotel.DDD.Dominio.Agregados.Habitacion.Entidades;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;
using hotel.DDD.Dominio.Agregados.Reserva.ObjetosDeValor.ObjetosDeValorReserva;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Repositorios
{
    internal interface IRepositorioHabitacion
    {
        Task AsignarHabitacion(HabitacionId habitacionId, ReservaId reservaId);
        Task ActualizarDetallesHabitacion(HabitacionId habitacionId, DetallesDeHabitacion detallesDeHabitacion);
        Task AgregarProducto(HabitacionId habitacionId, Producto producto);
        Task ActualizarDetallesDeProducto(DetallesDeProducto detallesDeProducto);
        Task EliminarProducto(HabitacionId habitacionId, ProductoId productoId);
    }
}
