using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Event_Context? _context;

        public EventoRepository(Event_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid Id, Evento evento)
        {

            try
            {
                Evento EventoBuscado = _context?.Evento.Find(Id)!;

                if (EventoBuscado != null)
                {
                    EventoBuscado.NomeEvento = evento.NomeEvento;

                    EventoBuscado.TiposEventosID = evento.TiposEventosID;

                    EventoBuscado.Descricao  = evento.Descricao;

                    EventoBuscado.DataEvento = evento.DataEvento;
                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Evento BuscarPorID(Guid Id)
        {
            try
            {
                Evento EventoBuscado = _context?.Evento.Find(Id)!;
                return EventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                _context?.Evento.Add(novoEvento);
                _context?.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                Evento EventoBuscado = _context?.Evento.Find(Id)!;
                if (EventoBuscado != null)
                {
                    _context?.Evento.Remove(EventoBuscado);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                List<Evento> ListaTiposEventos = _context?.Evento.ToList()!;
                return ListaTiposEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorID(Guid Id)
        {
            try
            {
                List<Evento> ListarPorID = _context?.Evento.ToList()!;
                return ListarPorID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarProximoEvento()
        {
            try
            {
                List<Evento> ListarProximoEvento = _context?.Evento.ToList()!;
                return ListarProximoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
