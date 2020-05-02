using MediatR;
using Pets.Core.Query.Contracts.Usuario.Queries;
using Pets.Core.Query.Contracts.Usuario.Results;

namespace Pets.Core.Query.Usuario.Handlers
{
    public class GetUsuarioRequest : GetUsuario, IRequest<GetUsuarioResult>
    {
    }
}
