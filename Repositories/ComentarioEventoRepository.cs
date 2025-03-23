using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly Event_Context? _context;

        public ComentarioEventoRepository(Event_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdDoUsuario(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentarioEvento ComentarioEventoBuscado = _context.ComentarioEvento.Find(EventoID)!;
                return ComentarioEventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _context?.ComentarioEvento.Add(comentarioEvento);
                _context?.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid ComentarioEventoID)
        {
            try
            {
               ComentarioEvento comentarioEvento = _context?.ComentarioEvento.Find()!;
                if (comentarioEvento != null)
                {
                    _context?.ComentarioEvento.Remove(comentarioEvento);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                List<ComentarioEvento> ListaComentarioEvento = _context?.ComentarioEvento.ToList()!;
                return (ListaComentarioEvento);
            }
            catch { }
        }

    }
}
