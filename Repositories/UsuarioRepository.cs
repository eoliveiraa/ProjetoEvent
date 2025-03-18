using Event_.Context;
using Event_.Domains;
using Event_.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly Event_Context _Context;

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _Context.Usuario.Find(id)!;

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

        public void Cadastrar(Usuario novousuario)
        {
            throw new NotImplementedException();
        }
    }
}
