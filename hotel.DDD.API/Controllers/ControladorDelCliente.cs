using hotel.DDD.Dominio.Agregados.Cliente.Entidades;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Cliente;
using hotel.DDD.Dominio.Comandos.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace hotel.DDD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDelCliente : ControllerBase
    {
        private readonly IClienteCasoDeUso _clienteCasoDeUso;

        public ControladorDelCliente(IClienteCasoDeUso clienteCasoDeUso)
        {
            _clienteCasoDeUso = clienteCasoDeUso;
        }

        [HttpGet("{id}")]
        public async Task<Cliente> ObtenerCliente(Guid id)
        {
            var cliente = await _clienteCasoDeUso.ObtenerClientePorId(id);
            return cliente;
        }

        [HttpPost]
        public async Task<Cliente> RegistrarCliente(RegistrarClienteComando comando)
        {
            var cliente = await _clienteCasoDeUso.RegistrarCliente(comando);
            return cliente;
        }

        [HttpPatch("ActualizarDatosPersonales")]
        public async Task<Cliente> ActualizarDatosPersonalesDelCliente(
            ActualizarClienteComando comando)
        {
            var cliente = await _clienteCasoDeUso.ActualizarDatosPersonalesDelCliente(comando);


            return cliente;
        }


        [HttpPost("PQR")]
        public async Task<IActionResult> AgregarPQRAlCliente(AgregarPQRComando comando)
        {
            var cliente = await _clienteCasoDeUso.AgregarPQRAlCliente(comando);
            return Ok(cliente);
        }

        [HttpPatch("ActualizarDetallesDelPQR")]
        public async Task<IActionResult> ActualizarDetallesDelPQR(ActualizarDetallesDelPQRComando comando)
        {
            var cliente = await _clienteCasoDeUso.ActualizarPQRDelCliente(comando);
            return Ok(cliente);
        }
    }
}
