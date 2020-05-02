using MediatR;
using Pets.Core.Query.Contracts.Pet.Commands;
using Pets.Core.Query.Contracts.Pet.Results;

namespace Pets.Core.Query.Pet.Requests
{
    public class AdicionarPetImagemRequest : AdicionarPetImagem, IRequest<AdicionarPetImagemResult>
    {
    }
}
