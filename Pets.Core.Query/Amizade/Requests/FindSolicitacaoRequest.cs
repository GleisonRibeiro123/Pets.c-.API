using MediatR;
using Pets.Core.Query.Contracts.Amizade.Queries;
using Pets.Core.Query.Contracts.Amizade.Results;
using System.Collections.Generic;

namespace Pets.Core.Query.Amizade.Requests
{
    public class FindSolicitacaoRequest : FindSolicitacao, IRequest<List<FindSolicitacaoResult>>
    {
    }
}
