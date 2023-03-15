using hotel.DDD.Dominio.Agregados.Habitacion.Entidades;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Habitacion;
using hotel.DDD.Dominio.Comandos.Habitacion;
using Microsoft.AspNetCore.Mvc;

namespace hotel.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDeLaHabitacion : ControllerBase
    {
        private readonly IHabitacionCasoDeUso _habitacionCasoDeUso;
        public ControladorDeLaHabitacion(IHabitacionCasoDeUso habitacionCasoDeUso)
        {
            _habitacionCasoDeUso = habitacionCasoDeUso;
        }

        [HttpGet("{id}")]
        public async Task<Habitacion> ObtenerHabitacionPorId(Guid id)
        {
            var habitacion = await _habitacionCasoDeUso.ObtenerHabitacionPorId(id);
            return habitacion;
        }

        [HttpPost]
        public async Task<Habitacion> AsignarHabitacion(AsignarHabitacionComando comando)
        {
            var habitacion = await _habitacionCasoDeUso.AsignarHabitacion(comando);
            return habitacion;
        }

        [HttpPost("AsignarTipoDeHabitacion")]
        public async Task<Habitacion> AsignarTipoDeHabitacion(AsignarTipoDeHabitacionComando comando)
        {
            var habitacion = await _habitacionCasoDeUso.AsignarTipoDeHabitacion(comando);
            return habitacion;
        }

        [HttpPost("AgregarProducto")]
        public async Task<Habitacion> AgregarProducto(AgregarProductoComando comando)
        {
            var habitacion = await _habitacionCasoDeUso.AgregarProducto(comando);
            return habitacion;
        }

        //[HttpPost("ActualizarDetallesDeProducto")]
        //public async Task<Habitacion> ActualizarProducto(ActualizarDetallesDelProductoComando comando)
        //{
        //    var habitacion = await _habitacionCasoDeUso.ActualizarDetallesDelProducto(comando);
        //    return habitacion;
        //}
    }
}
