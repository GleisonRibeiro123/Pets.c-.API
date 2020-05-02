using MediatR;
using Pets.Core.Query.Contracts.Usuario.Commands;
using Pets.Core.Query.Contracts.Usuario.Results;

namespace Pets.Core.Query.Usuario.Handlers
{
    public class AdicionarUsuarioRequest : AdicionarUsuario, IRequest<AdicionarUsuarioResult>
    {
    }
}
