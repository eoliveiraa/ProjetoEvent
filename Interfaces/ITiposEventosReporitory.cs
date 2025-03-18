using Event_.Domains;

namespace Event_.Interfaces
{
    public interface ITiposEventosReporitory
    {
        void Cadastrar (TiposEventos tiposEventos);

        void Atualizar (Guid Id,TiposEventos tiposEventos);

        void Deletar(Guid Id);

        List<TiposEventos> Listar();

        TiposEventos BuscarPorId (Guid Id);


    }
}
