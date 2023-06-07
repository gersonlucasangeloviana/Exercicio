using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Handlers;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("movimentarConta")]
    [ApiController]
    public class MovimentoContaController : ControllerBase
    {
        IIdempotenciaRepository _indempontencia;
        public MovimentoContaController(IIdempotenciaRepository indempontencia)
        {
            _indempontencia = indempontencia;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(
                  [FromServices] ICreateMovimentoHandler handler,
                  [FromBody] CreateMovimentoRequest command
              )
        {
            try
            {
                var requisicaoJaRealizada = _indempontencia.Consultar(command.IdRequisicao);
                if (!string.IsNullOrEmpty(requisicaoJaRealizada))
                {
                    return Ok(requisicaoJaRealizada);
                }

                var response = handler.Handle(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
            
        }
    }
}
