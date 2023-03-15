using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Habitacion;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class ReconstruccionDeLaHabitacion
    {
        public Habitacion CrearAgregado(List<EventoDeDominio> eventos, HabitacionId id)
        {
            Habitacion habitacion = new Habitacion(id);
            eventos.ForEach(evento =>
            {
                switch (evento)
                {
                    case EstadoDeLaHabitacionActualizado estadoDeHabitacionAsignado:
                        habitacion.ActualizarEstadoDeHabitacionAgregado();
                        break;
                    case NumeroDeHabitacionAsignado numeroDeHabitacionAsignado:
                        habitacion.AsignarNumeroDeHabitacionAgregado(numeroDeHabitacionAsignado.numeroDeHabitacion);
                        break;
                    case TipoDeHabitacionAsignado tipoDeHabitacionAsignado:
                        habitacion.AsignarTipoDeHabitacionAgregado(tipoDeHabitacionAsignado.tipoDeHabitacion);
                        break;
                    case DetallesDeHabitacionAgregados detallesDeLaHabitacionAgregados:
                        habitacion.SetDetallesDeHabitacionAgregado(detallesDeLaHabitacionAgregados.detallesDeHabitacion);
                        break;
                    case ProductoAgregado productoAgregado:
                        habitacion.AgregarProductoAgregado(productoAgregado.producto);
                        break;
                    case DetallesDeProductoAgregados detallesDeProductoAgregado:
                        habitacion.AgregarDetallesDeProductoAgregado(detallesDeProductoAgregado.detallesDeProducto);
                        break;
                        //case DetallesDelProductoActualizados detallesDeProductoActualizados:
                        //    habitacion.ActualizarDetallesDeProductoAgregado(detallesDeProductoActualizados.ProductoId,
                        //        detallesDeProductoActualizados.DetallesDeProducto);
                        //    break;
                }
            });
            return habitacion;
        }
    }
}
