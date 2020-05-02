using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pets.Core.Query.Usuario.Handlers;
using Pets.Core.Query.Usuario.Requests;
using System.Threading.Tasks;

namespace Pets.Core.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("find")]
        public async Task<IActionResult> FindAsync(FindUsuarioRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetAsync(GetUsuarioRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarAsync(AdicionarUsuarioRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
