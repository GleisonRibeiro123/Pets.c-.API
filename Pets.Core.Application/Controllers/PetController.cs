using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pets.Core.Query.Pet.Requests;
using System.Threading.Tasks;

namespace Pets.Core.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private readonly IMediator _mediator;
        public PetController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("find")]
        public async Task<IActionResult> FindAsync(FindPetRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetAsync(GetPetRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarAsync(AdicionarPetRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpPost("adicionarimagem")]
        public async Task<IActionResult> AdicionarPetImagem(AdicionarPetImagemRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}