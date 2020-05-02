using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Contracts.Pet.Results;
using Pets.Core.Query.Pet.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Pet.Handlers
{
    public class GetPetHandler : IRequestHandler<GetPetRequest, GetPetResult>
    {
        private readonly PetsDbContext _dbContext;
        public GetPetHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<GetPetResult> Handle(GetPetRequest request, CancellationToken cancellationToken)
        {
            var pet = _dbContext.Pet.Single(p => p.Id == request.PetId);

            var result = new GetPetResult
            {
                Id = pet.Id,
                Nome = pet.Nome,
                Especie = pet.Especie,
                Raca = pet.Raca,
                Sexo = pet.Sexo,
                UsuarioId = pet.UsuarioId,
                DataNascimento = pet.DataNascimento,
                Descricao = pet.Descricao,
                Imagem = null
            };
            return Task.FromResult(result);
        }
    }
}
