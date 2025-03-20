using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private readonly Event_Context? _context;

        public TiposUsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, TiposUsuarios tiposUsuarios)
        {
            throw new NotImplementedException();
        }

        public TiposUsuarios BuscarPorID(Guid Id)
        {
            try
            {
                TiposUsuarios tipousuarioBuscado = _context?.TiposUsuarios.Find(Id)!;

                if (tipousuarioBuscado != null)
                {
                    return tipousuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TiposUsuarios tiposUsuarios)
        {
            try
            {
                tiposUsuarios.TituloTipoUsuario = tiposUsuarios.TituloTipoUsuario;

                _context?.TiposUsuarios.Add(tiposUsuarios);

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
                TiposUsuarios tipoUsuarioBuscado = _context?.TiposUsuarios.Find(Id)!;
                if (tipoUsuarioBuscado != null)
                {
                    _context?.TiposUsuarios.Remove(tipoUsuarioBuscado);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposUsuarios> Listar()
        {
            try
            {
                List<TiposUsuarios> ListaTiposUsuarios = _context?.TiposUsuarios.ToList()!;
                return ListaTiposUsuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
