using Event_.Domains;
using Event_.Interfaces;
using Event_.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event_.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]

        public class TiposEventosController : ControllerBase
        {
            private readonly ITiposEventosRepository _tiposEventosRepository;

            public TiposEventosController(ITiposEventosRepository tiposEventosRepository)
            {
                _tiposEventosRepository = tiposEventosRepository;
            }

            /// <summary>
            /// Endpoint para atualizar o filme
            /// </summary>
            /// <param name="id"></param>
            /// <param name="TiposEventos"></param>
            /// <returns></returns>
            [HttpPut("{Id}")]
            public IActionResult TiposEventos(Guid Id, TiposEventos tiposEventos) {
                try
                {
                    _tiposEventosRepository.Atualizar(Id, tiposEventos);
                    return NoContent();

                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }


            [HttpGet("BuscarPorId{Id}")]
            public IActionResult GetById(Guid Id)
            {

                try
                {
                    TiposEventos tipoEventoBuscado = _tiposEventosRepository.BuscarPorId(Id);
                    return Ok (tipoEventoBuscado);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }

            [HttpPost]
            public IActionResult Post(TiposEventos novoTipoEvento)
            {

            try
            {
                _tiposEventosRepository.Cadastrar(novoTipoEvento);
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
                    _tiposEventosRepository.Deletar(Id);
                    return NoContent();
                }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposEventos> ListaTipoEvento = _tiposEventosRepository.Listar();
                return Ok(ListaTipoEvento);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }



        
    }


}
    

