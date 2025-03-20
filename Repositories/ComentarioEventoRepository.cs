using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class ComentarioEventoRepository:IComentarioEventoRepository
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
            throw new NotImplementedException();
        }

        public void Deletar(Guid IdComentario)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> Listar(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
