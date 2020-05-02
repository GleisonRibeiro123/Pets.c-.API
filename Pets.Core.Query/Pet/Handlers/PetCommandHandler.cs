using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Pet.Results;
using Pets.Core.Query.Pet.Requests;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Pet.Handlers
{
    public class PetCommandHandler : IRequestHandler<AdicionarPetRequest, AdicionarPetResult>,
                                     IRequestHandler<AdicionarPetImagemRequest, AdicionarPetImagemResult>
    {
        private readonly PetsDbContext _dbContext;
        public PetCommandHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<AdicionarPetResult> Handle(AdicionarPetRequest request, CancellationToken cancellationToken)
        {
            _dbContext.Pet.Add(new PetEntity
            {
                Id = request.Id,
                Nome = request.Nome,
                Especie = request.Especie,
                Raca = request.Raca,
                Sexo = request.Sexo,
                DataNascimento = request.DataNascimento,
                Descricao = request.Descricao,
                UsuarioId = request.UsuarioId
            });

            _dbContext.SaveChanges();

            var petSalvo = _dbContext.Pet.Single(u => u.Id == request.Id);
            return Task.FromResult(new AdicionarPetResult
            {
                Id = petSalvo.Id,
                Nome = petSalvo.Nome,
                Especie = petSalvo.Especie,
                Raca = petSalvo.Raca,
                Sexo = petSalvo.Sexo,
                DataNascimento = petSalvo.DataNascimento,
                Descricao = petSalvo.Descricao,
                UsuarioId = petSalvo.UsuarioId
            });
        }

        public Task<AdicionarPetImagemResult> Handle(AdicionarPetImagemRequest request, CancellationToken cancellationToken)
        {
            _dbContext.Imagem.Add(new ImagemEntity
            {
                Id = request.Id,
                Imagem = request.Imagem
            });

            foreach (var id in request.UsuariosDependentesId)
            {
                _dbContext.PetImagem.Add(new PetImagemEntity
                {
                    CriadorId = request.UsuarioTitularId,
                    ImagemId = request.Id,
                    PetId = request.PetId,
                    UsuarioMarcadoId = id
                });
            }

            _dbContext.SaveChanges();

            var imagemSalva = _dbContext.Imagem.Single(i => i.Id == request.Id);

            return Task.FromResult(new AdicionarPetImagemResult
            {
                Id = imagemSalva.Id,
                Imagem = imagemSalva.Imagem
            });
        }
    }
}
