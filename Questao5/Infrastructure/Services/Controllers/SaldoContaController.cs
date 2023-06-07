using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Handlers;
using Questao5.Infrastructure.Database.Repository;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("SaldoConta")]
    [ApiController]
    public class SaldoContaController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public IActionResult Post(
                [FromServices] IGetContaCorrenteHandler handler,
                [FromBody] GetSaldoRequest command
            )
        {
            try
            {
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
