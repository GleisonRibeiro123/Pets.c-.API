using MediatR;
using Pets.Core.Query.Contracts.Amizade.Commands;
using Pets.Core.Query.Contracts.Amizade.Results;

namespace Pets.Core.Query.Amizade.Requests
{
    public class ResponderSolicitacaoRequest : ResponderSolicitacao, IRequest<ResponderSolicitacaoResult>
    {
    }
}
