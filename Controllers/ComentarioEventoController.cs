using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _ComentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _ComentarioEventoRepository = comentarioEventoRepository;
        }

        [HttpGet("{Id}")]
        public IActionResult Get(Guid UsuarioID, Guid EventoID)
        {
           
        }

        [HttpPost]
        public IActionResult Post(ComentarioEventoRepository comentarioEvento)
        {

            try
            {
                _ComentarioEventoRepository.Cadastrar(comentarioEvento);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]

        public IActionResult Delete(Guid Id)
        {
            try
            {
                _ComentarioEventoRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<ComentarioEvento> ListarComentarioEvento = _ComentarioEventoRepository.Listar(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
