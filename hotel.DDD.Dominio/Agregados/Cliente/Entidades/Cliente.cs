using System.Text.Json.Serialization;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorCliente;
using hotel.DDD.Dominio.Agregados.Cliente.ObjetosDeValor.ObjetosDeValorPQR;
using hotel.DDD.Dominio.Comun;

namespace hotel.DDD.Dominio.Agregados.Cliente.Entidades
{
    public class Cliente : EventoDeAgregado<ClienteId>
    {
        public ClienteId ClienteId { get; init; }
        public DatosPersonales DatosPersonales { get; private set; }

        public virtual List<Reserva.Entidades.Reserva>? Reservas { get; private set; }

        public virtual List<PQR>? PQRs { get; private set; }

        #region Metodos de Cliente como gestor de eventos
        public Cliente(ClienteId id) : base(id)
        {
            this.ClienteId = id;
        }

        public void SetDatosPersonales(DatosPersonales datosPersonales)
        {
            this.DatosPersonales = datosPersonales;
        }


        #endregion

        #region Metodos de Cliente como entidad

        public void AgregarReserva(Reserva.Entidades.Reserva reserva) //Pendiente por implementar
        {
            if (Reservas == null)
            {
                Reservas = new List<Reserva.Entidades.Reserva>();
            }
            Reservas.Add(reserva);
        }

        public void AgregarPQR(PQR pqr)
        {
            if (PQRs == null)
            {
                PQRs = new List<PQR>();
            }
            PQRs.Add(pqr);
        }

        public void AgregarDetallesDelPQR(DetallesDelPQR detallesDelPqr)
        {
            PQRs?.Last().SetDetallesDelPQR(detallesDelPqr);
        }
        #endregion


    }
}
