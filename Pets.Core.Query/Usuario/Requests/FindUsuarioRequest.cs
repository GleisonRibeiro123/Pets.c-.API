using MediatR;
using Pets.Core.Query.Contracts.Usuario.Queries;
using Pets.Core.Query.Contracts.Usuario.Results;
using System.Collections.Generic;

namespace Pets.Core.Query.Usuario.Requests
{
    public class FindUsuarioRequest : FindUsuario, IRequest<List<FindUsuarioResult>>
    {
    }
}
