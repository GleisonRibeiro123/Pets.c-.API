using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pets.Core.Query.Amizade.Requests;
using System.Threading.Tasks;

namespace Pets.Core.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmizadeController : Controller
    {
        private readonly IMediator _mediator;
        public AmizadeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("find")]
        public async Task<IActionResult> FindAsync(FindAmizadeRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("findsolicitacao")]
        public async Task<IActionResult> FindSolicitacaoAsync(FindSolicitacaoRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("solicitar")]
        public async Task<IActionResult> SolicitarAsync(SolicitarAmizadeRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("respondersolicitacao")]
        public async Task<IActionResult> ResponderAsync(ResponderSolicitacaoRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}