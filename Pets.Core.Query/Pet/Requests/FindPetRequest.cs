using MediatR;
using Pets.Core.Query.Contracts.Pet.Queries;
using Pets.Core.Query.Contracts.Pet.Results;
using System.Collections.Generic;

namespace Pets.Core.Query.Pet.Requests
{
    public class FindPetRequest : FindPet, IRequest<List<FindPetResult>>
    {
    }
}
