using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class TiposEventosRepository : ITiposEventosRepository
    {

        private readonly Event_Context? _context;

        public TiposEventosRepository (Event_Context context)
        {
            _context = context;
        }

        
        //variavel
        //metodo construtor
        //Desenvolver os metodos que foram criados na interface
        public void Atualizar(Guid Id, TiposEventos tiposEventos)
        {
            try
            {
                TiposEventos TipoEventoBuscado = _context?.TiposEventos.Find(Id)!;

                if (TipoEventoBuscado != null)
                {
                    TipoEventoBuscado.TiposEventosID = tiposEventos.TiposEventosID;

                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposEventos BuscarPorId(Guid Id)
        {
            try
            {
                TiposEventos TipoEventoBuscado = _context?.TiposEventos.Find(Id)!;
                return TipoEventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposEventos novoEvento)
        {
            try
            {
                _context?.TiposEventos.Add(novoEvento);
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
                TiposEventos TipoEventoBuscado = _context?.TiposEventos.Find(Id)!;
                if (TipoEventoBuscado != null)
                {
                    _context?.TiposEventos.Remove(TipoEventoBuscado);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposEventos> Listar()
        {
            try
            {
                List<TiposEventos> ListaTiposEventos = _context?.TiposEventos.ToList()!;
                return ListaTiposEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
