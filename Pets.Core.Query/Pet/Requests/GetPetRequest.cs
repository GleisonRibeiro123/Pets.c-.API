using MediatR;
using Pets.Core.Query.Contracts.Pet.Queries;
using Pets.Core.Query.Contracts.Pet.Results;

namespace Pets.Core.Query.Pet.Requests
{
    public class GetPetRequest : GetPet, IRequest<GetPetResult>
    {
    }
}
