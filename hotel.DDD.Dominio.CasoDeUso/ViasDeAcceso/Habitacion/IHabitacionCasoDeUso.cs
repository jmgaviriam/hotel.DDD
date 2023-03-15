using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Comandos.Habitacion;

namespace hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Habitacion
{
    public interface IHabitacionCasoDeUso
    {

        Task<Agregados.Habitacion.Entidades.Habitacion> ObtenerHabitacionPorId(Guid HabitacionId);
        Task<Agregados.Habitacion.Entidades.Habitacion> AsignarHabitacion(AsignarHabitacionComando comando);
        Task<Agregados.Habitacion.Entidades.Habitacion> AsignarTipoDeHabitacion(AsignarTipoDeHabitacionComando comando);
        Task<Agregados.Habitacion.Entidades.Habitacion> AgregarProducto(AgregarProductoComando comando);
        //Task<Agregados.Habitacion.Entidades.Habitacion> ActualizarDetallesDelProducto(ActualizarDetallesDelProductoComando comando);

    }
}
