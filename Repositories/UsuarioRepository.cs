using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Event_Context? _context;

        public UsuarioRepository(Event_Context context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {

            try
            {
                Usuario usuarioBuscado = _context?.Usuario.FirstOrDefault(u => u.Email == email)!;
                

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context?.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {

            try
            {
                novoUsuario.Senha = novoUsuario.Senha!;

                _context?.Usuario.Add(novoUsuario);
                _context?.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
