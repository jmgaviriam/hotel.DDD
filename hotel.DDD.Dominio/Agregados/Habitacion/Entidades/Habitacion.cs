using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorHabitacion;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorProducto;
using hotel.DDD.Dominio.Agregados.Habitacion.ObjetosDeValor.ObjetosDeValorTipoDeHabitacion;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Habitacion;

namespace hotel.DDD.Dominio.Agregados.Habitacion.Entidades
{
    public class Habitacion : EventoDeAgregado<HabitacionId>
    {
        public HabitacionId HabitacionId { get; init; }
        public NumeroDeHabitacion NumeroDeHabitacion { get; private set; }
        public EstadoDeLaHabitacion EstadoDeHabitacion { get; private set; }

        public virtual TipoDeHabitacion TipoDeHabitacion { get; private set; }
        public virtual List<Producto>? Productos { get; private set; }

        #region Metodos de Cliente como gestor de eventos
        public Habitacion(HabitacionId habitacionId) : base(habitacionId)
        {
            this.HabitacionId = habitacionId;
        }

        public void setHabitacionId(HabitacionId habitacionId)
        {
            AgregarEvento(new HabitacionAsignada(habitacionId.ToString()));
        }

        public void ActualizarEstadoDeHabitacion()
        {
            AgregarEvento(new EstadoDeLaHabitacionActualizado());
        }

        public void AsignarNumeroDeHabitacion(NumeroDeHabitacion numeroDeHabitacion)
        {
            AgregarEvento(new NumeroDeHabitacionAsignado(numeroDeHabitacion));
        }

        public void AsignarTipoDeHabitacion(TipoDeHabitacion tipoDeHabitacion)
        {
            AgregarEvento(new TipoDeHabitacionAsignado(tipoDeHabitacion));
        }

        public void SetDetallesDeHabitacion(DetallesDeHabitacion detallesDeHabitacion)
        {
            AgregarEvento(new DetallesDeHabitacionAgregados(detallesDeHabitacion));
        }

        public void AgregarProducto(Producto producto)
        {
            AgregarEvento(new ProductoAgregado(producto));
        }

        public void AgregarDetallesDeProducto(DetallesDeProducto detallesDeProducto)
        {
            AgregarEvento(new DetallesDeProductoAgregados(detallesDeProducto));
        }

        //public void ActualizarDetallesDelProducto(Guid productoId, DetallesDeProducto detallesDeProducto)
        //{
        //    var producto = Productos.FirstOrDefault(x => x.Id == productoId);
        //    if (producto != null)
        //    {
        //        producto.ActualizarDetallesDeProducto(detallesDeProducto);
        //        AgregarEvento(new DetallesDelProductoActualizados(productoId, detallesDeProducto));
        //    }
        //    else
        //    {
        //        throw new Exception("No se encontro el producto con Id {productoId} en la habitacion {this.HabitacionId}");
        //    }
        //}

        #endregion


        #region Metodos de la Habitacion como entidad

        public void ActualizarEstadoDeHabitacionAgregado()
        {
            this.EstadoDeHabitacion = EstadoDeLaHabitacion.Create(false);
        }

        public void AsignarNumeroDeHabitacionAgregado(NumeroDeHabitacion numeroDeHabitacion)
        {
            this.NumeroDeHabitacion = numeroDeHabitacion;
        }

        public void AsignarTipoDeHabitacionAgregado(TipoDeHabitacion tipoDeHabitacion)
        {
            this.TipoDeHabitacion = tipoDeHabitacion;
        }

        public void SetDetallesDeHabitacionAgregado(DetallesDeHabitacion detallesDeHabitacion)
        {
            this.TipoDeHabitacion.DetallesDeHabitacion = detallesDeHabitacion;
        }

        public void AgregarProductoAgregado(Producto producto)
        {
            if (this.Productos == null)
            {
                this.Productos = new List<Producto>();
            }
            this.Productos.Add(producto);
        }

        public void AgregarDetallesDeProductoAgregado(DetallesDeProducto detallesDeProducto)
        {
            Productos?.Last().AgregarDetallesDeProducto(detallesDeProducto);
        }

        ////public void ActualizarDetallesDeProductoAgregado(Guid productoId, DetallesDeProducto detallesDeProducto)
        ////{
        ////    var producto = this.Productos.FirstOrDefault(x => x.Id == productoId);
        ////    if (producto != null)
        ////    {
        ////        producto.ActualizarDetallesDeProducto(detallesDeProducto);
        ////    }
        ////    else
        ////    {
        ////        throw new Exception("No se encontro el producto con Id {productoId} en la habitacion {this.HabitacionId}");
        ////    }
        ////}

        #endregion
    }


}
