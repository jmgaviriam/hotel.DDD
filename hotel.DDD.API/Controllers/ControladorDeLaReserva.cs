using hotel.DDD.Dominio.Agregados.Reserva.Entidades;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Reserva;
using hotel.DDD.Dominio.Comandos.Reserva;
using Microsoft.AspNetCore.Mvc;

namespace hotel.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDeLaReserva : ControllerBase
    {
        private readonly IReservaCasoDeUso _reservaCasoDeUso;

        public ControladorDeLaReserva(IReservaCasoDeUso reservaCasoDeUso)
        {
            _reservaCasoDeUso = reservaCasoDeUso;
        }

        [HttpGet("{id}")]
        public async Task<Reserva> ObtenerReservaPorId(Guid id)
        {
            var reserva = await _reservaCasoDeUso.ObtenerReservaPorId(id);
            return reserva;
        }

        [HttpPost]
        public async Task<Reserva> CrearReserva(CrearReservaComando comando)
        {
            var reserva = await _reservaCasoDeUso.CrearReserva(comando);
            return reserva;
        }

        [HttpPost("AsignarFuncionario")]
        public async Task<Reserva> AsignarFuncionario(AsignarFuncionarioComando comando)
        {
            var reserva = await _reservaCasoDeUso.AsignarFuncionario(comando);
            return reserva;
        }

        [HttpPost("AsignarMedioDePago")]
        public async Task<Reserva> AsignarMedioDePago(AsignarMedioDePagoComando comando)
        {
            var reserva = await _reservaCasoDeUso.AsignarMedioDePago(comando);
            return reserva;
        }


    }
}
