using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.Entidades;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Eventos;
using hotel.DDD.Dominio.CasoDeUso.ViasDeAcceso.Habitacion;
using hotel.DDD.Dominio.Comandos.Habitacion;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Habitacion;
using hotel.DDD.Dominio.Generico;
using Newtonsoft.Json;

namespace hotel.DDD.Dominio.CasoDeUso.CasosDeUso.Habitacion
{
    public class HabitacionCasoDeUso : IHabitacionCasoDeUso
    {
        private readonly IRepositorioDeEventos<EventoGuardado> _repositorioDeEventos;

        public HabitacionCasoDeUso(IRepositorioDeEventos<EventoGuardado> repositorioDeEventos)
        {
            _repositorioDeEventos = repositorioDeEventos;
        }


        public async Task<Agregados.Habitacion.Entidades.Habitacion> ObtenerHabitacionPorId(Guid habitacionId)
        {
            var reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            var ListadoDeEventos = await ObtenerEventosPorAgregadoId(habitacionId.ToString());
            var habitacionID = HabitacionId.Create(habitacionId);
            var habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionID);
            return habitacionReconstruida;
        }

        public async Task<Agregados.Habitacion.Entidades.Habitacion> AsignarHabitacion(AsignarHabitacionComando comando)
        {
            var habitacion = new Agregados.Habitacion.Entidades.Habitacion(HabitacionId.Create(Guid.NewGuid()));
            habitacion.setHabitacionId(habitacion.HabitacionId);
            habitacion.ActualizarEstadoDeHabitacion();

            var numeroDeHabitacion = NumeroDeHabitacion.Create(comando.NumeroDeHabitacion);
            habitacion.AsignarNumeroDeHabitacion(numeroDeHabitacion);
            List<EventoDeDominio> eventosDeDominio = habitacion.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            var reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            habitacion = reconstruccionDeLaHabitacion.CrearAgregado(eventosDeDominio, habitacion.HabitacionId);
            return habitacion;
        }

        public async Task<Agregados.Habitacion.Entidades.Habitacion> AsignarTipoDeHabitacion(AsignarTipoDeHabitacionComando comando)
        {
            var reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            var ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
            var habitacionId = HabitacionId.Create(Guid.Parse(comando.HabitacionId));
            var habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);

            var TipoDeHabitacion = new TipoDeHabitacion(TipoDeHabitacionId.Create(Guid.NewGuid()));
            var detallesDeHabitacion = DetallesDeHabitacion.Create(
                comando.categoria,
                comando.capacidad,
                comando.precioPorNoche);
            habitacionReconstruida.AsignarTipoDeHabitacion(TipoDeHabitacion);
            habitacionReconstruida.SetDetallesDeHabitacion(detallesDeHabitacion);
            List<EventoDeDominio> eventosDeDominio = habitacionReconstruida.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
            habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);
            return habitacionReconstruida;
        }

        public async Task<Agregados.Habitacion.Entidades.Habitacion> AgregarProducto(AgregarProductoComando comando)
        {
            var reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            var ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
            var habitacionId = HabitacionId.Create(Guid.Parse(comando.HabitacionId));
            var habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);

            var producto = new Producto(ProductoId.Create(Guid.NewGuid()));
            var detallesDeProducto = DetallesDeProducto.Create(
                comando.Nombre,
                comando.Descripcion,
                comando.Precio,
                comando.Cantidad);
            habitacionReconstruida.AgregarProducto(producto);
            habitacionReconstruida.AgregarDetallesDeProducto(detallesDeProducto);
            List<EventoDeDominio> eventosDeDominio = habitacionReconstruida.ObtenerCambios();
            await GuardarEventos(eventosDeDominio);

            reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
            ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
            habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);
            return habitacionReconstruida;
        }

        //public async Task<Agregados.Habitacion.Entidades.Habitacion> ActualizarDetallesDelProducto(ActualizarDetallesDelProductoComando comando)
        //{
        //    var reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
        //    var ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
        //    var habitacionId = HabitacionId.Create(Guid.Parse(comando.HabitacionId));
        //    var habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);

        //    var detallesDeProducto = DetallesDeProducto.Create(
        //        comando.Nombre,
        //        comando.Descripcion,
        //        comando.Precio,
        //        comando.Cantidad);

        //    habitacionReconstruida.ActualizarDetallesDelProducto(Guid.Parse(comando.HabitacionId), detallesDeProducto);
        //    List<EventoDeDominio> eventosDeDominio = habitacionReconstruida.ObtenerCambios();
        //    await GuardarEventos(eventosDeDominio);

        //    reconstruccionDeLaHabitacion = new ReconstruccionDeLaHabitacion();
        //    ListadoDeEventos = await ObtenerEventosPorAgregadoId(comando.HabitacionId);
        //    habitacionReconstruida = reconstruccionDeLaHabitacion.CrearAgregado(ListadoDeEventos, habitacionId);
        //    return habitacionReconstruida;
        //}


        private async Task<List<EventoDeDominio>> ObtenerEventosPorAgregadoId(string comandoHabitacionId)
        {
            var listadoDeEventos = await _repositorioDeEventos.ObtenerEventosPorAgregadoId(comandoHabitacionId);
            if (listadoDeEventos == null)

                throw new Exception("No se encontraron eventos asociados a ese Id");

            return listadoDeEventos.Select(ev =>
            {
                string nombre = $"hotel.DDD.Dominio.Eventos.Habitacion.{ev.NombreGuardado}, hotel.DDD.Dominio";
                Type tipo = Type.GetType(nombre);
                EventoDeDominio evento = (EventoDeDominio)JsonConvert.DeserializeObject(ev.CuerpoDelEvento, tipo);
                return evento;
            }).ToList();
        }


        private async Task GuardarEventos(List<EventoDeDominio> eventos)
        {
            var ArregloDeEventos = eventos.ToArray();
            for (var index = 0; index < ArregloDeEventos.Length; index++)
            {
                var EventoGuardado = new EventoGuardado();
                EventoGuardado.IdAgregado = ArregloDeEventos[index].ObtenerAgregadoId();
                EventoGuardado.NombreGuardado = ArregloDeEventos[index].ObtenerAgregado();

                switch (ArregloDeEventos[index])
                {
                    case HabitacionAsignada habitacionAsignada:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(habitacionAsignada);
                        break;
                    case EstadoDeLaHabitacionActualizado estadoDeLaHabitacionActualizado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(estadoDeLaHabitacionActualizado);
                        break;
                    case NumeroDeHabitacionAsignado numeroDeHabitacionAsignado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(numeroDeHabitacionAsignado);
                        break;
                    case TipoDeHabitacionAsignado tipoDeHabitacionAsignado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(tipoDeHabitacionAsignado);
                        break;
                    case DetallesDeHabitacionAgregados detallesDeHabitacionAgregados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(detallesDeHabitacionAgregados);
                        break;
                    case ProductoAgregado productoAgregado:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(productoAgregado);
                        break;
                    case DetallesDeProductoAgregados detallesDelProductoAgregados:
                        EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(detallesDelProductoAgregados);
                        break;
                        //case DetallesDelProductoActualizados detallesDelProductoActualizados:
                        //    EventoGuardado.CuerpoDelEvento = JsonConvert.SerializeObject(detallesDelProductoActualizados);
                        //    break;
                }
                await _repositorioDeEventos.AddAsync(EventoGuardado);
            }
            await _repositorioDeEventos.SaveChangesAsync();
        }
    }
}
