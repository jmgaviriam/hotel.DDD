using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;
using hotel.DDD.Dominio.Comun;
using hotel.DDD.Dominio.Eventos.Cliente;

namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class Cliente : EventoDeAgregado<ClienteId>
    {
        public ClienteId ClienteId { get; init; }
        public ClienteDatosPersonales DatosPersonales { get; private set; }

        public virtual HistorialDeReservas HistorialDeReservas { get; private set; }

        public virtual List<PQR>? PQRs { get; private set; }

        #region Metodos de Cliente como gestor de eventos
        public Cliente(ClienteId clienteId) : base(clienteId)
        {
            this.ClienteId = clienteId;
        }

        public void setClienteId(ClienteId clienteId)
        {
            AgregarEvento(new ClienteRegistrado(clienteId.ToString()));
        }

        public void SetDatosPersonales(ClienteDatosPersonales datosPersonales)
        {
            AgregarEvento(new DatosPersonalesAgregados(datosPersonales));

        }

        public void ActualizarDatosPersonales(ClienteDatosPersonales datosPersonales)
        {
            AgregarEvento(new DatosPersonalesActualizados(datosPersonales));
        }

        public void AgregarPQR(PQR pqr)
        {
            AgregarEvento(new PQRAgregado(pqr));
        }

        public void AgregarDetallesDelPQR(DetallesDelPQR detallesDelPqr)
        {
            AgregarEvento(new DetallesDelPQRAgregados(detallesDelPqr));
        }

        public void ActualizarDetallesDelPQR(Guid pqrId, DetallesDelPQR detallesDelPqr)
        {
            var pqr = PQRs.FirstOrDefault(x => x.Id == pqrId);
            if (pqr != null)
            {
                pqr.ActualizarDetalles(detallesDelPqr);
                AgregarEvento(new DetallesDelPQRActualizados(pqrId, detallesDelPqr));
            }
            else
            {
                throw new ArgumentException($"No se encontró el PQR con Id {pqrId}.");
            }
        }

        #endregion

        #region Metodos de Cliente como entidad

        public void SetDatosPersonalesAgregado(ClienteDatosPersonales datosPersonales)
        {
            this.DatosPersonales = datosPersonales;

        }

        public void ActualizarDatosPersonalesAgregado(ClienteDatosPersonales datosPersonales)
        {
            this.DatosPersonales = datosPersonales;
        }

        public void AgregarPQRAgregado(PQR pqr)
        {
            if (PQRs == null)
            {
                PQRs = new List<PQR>();
            }
            PQRs.Add(pqr);
        }

        public void AgregarDetallesDelPQRAgregado(DetallesDelPQR detallesDelPqr)
        {
            PQRs?.Last().SetDetallesDelPQR(detallesDelPqr);
        }

        public void ActualizarDetallesDelPQRAgregado(Guid pqrId, DetallesDelPQR detallesDelPqr)
        {
            var pqr = PQRs.FirstOrDefault(x => x.Id == pqrId);
            if (pqr != null)
            {
                pqr.ActualizarDetalles(detallesDelPqr);
            }
            else
            {
                throw new ArgumentException($"No se encontró el PQR con Id {pqrId}.");
            }
        }
        #endregion
    }
}
