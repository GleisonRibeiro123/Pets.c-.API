using MediatR;
using Pets.Core.Query.Contracts.Pet.Commands;
using Pets.Core.Query.Contracts.Pet.Results;

namespace Pets.Core.Query.Pet.Requests
{
    public class AdicionarPetRequest : AdicionarPet, IRequest<AdicionarPetResult>
    {
    }
}
