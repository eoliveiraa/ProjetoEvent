using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Event_.Repositories
{
    public class PresencasEventosRepository : IPresencasEventosRepository
    {
        private readonly Event_Context? _context;

        public PresencasEventosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, PresencasEventos presencasEventos)
        {
            try
            {
                PresencasEventos presencas = _context.Find(Id);
                if (presencas != null)
                {
                    presencasEventos.PresencasEventoID = presencasEventos.PresencasEventoID;

                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
           
        

        public PresencasEventos BuscarPorId(Guid Id)
        {
            try
            {
                PresencasEventos presencaBuscada = _context?.PresencasEventos.Find(Id)!;
                return presencaBuscada;
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
                PresencasEventos presencasEventos = _context?.PresencasEventos.Find(Id)!;
                if (presencasEventos != null)
                {
                    _context?.PresencasEventos.Remove(presencasEventos);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(PresencasEventos inscricao)
        {
            try
            {
            

            }
            catch
            {

            }
        }

        public List<PresencasEventos> Listar()
        {
            try
            {
                List<PresencasEventos> ListapresencasEventos = _context.PresencasEventos.ToList();
                return (ListapresencasEventos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEventos> ListarMinhas(Guid Id)
        {
            try
            {
                List<PresencasEventos> ListaMinhas = _context.PresencasEventos.ToList()!;
                return (ListaMinhas);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
