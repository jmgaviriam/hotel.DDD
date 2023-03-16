using hotel.DDD.Dominio.Generico;

namespace hotel.DDD.Pruebas.Cliente.Constructores
{
    public class ConstructorDeEventoGuardado
    {
        public int IdGuardado;
        public string NombreGuardado;
        public string IdAgregado;
        public string CuerpoDelEvento;

        public ConstructorDeEventoGuardado ConIdGuardado(int idGuardado)
        {
            IdGuardado = idGuardado;
            return this;
        }

        public ConstructorDeEventoGuardado ConNombreGuardado(string nombreGuardado)
        {
            NombreGuardado = nombreGuardado;
            return this;
        }

        public ConstructorDeEventoGuardado ConIdAgregado(string idAgregado)
        {
            IdAgregado = idAgregado;
            return this;
        }

        public ConstructorDeEventoGuardado ConCuerpoDelEvento(string cuerpoDelEvento)
        {
            CuerpoDelEvento = cuerpoDelEvento;
            return this;
        }

        public EventoGuardado Construir()
        {
            return new EventoGuardado(IdGuardado, NombreGuardado, IdAgregado, CuerpoDelEvento);
        }
    }
}
