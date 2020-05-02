using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Pet.Results;
using Pets.Core.Query.Pet.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Pet.Handlers
{
    public class FindPetHandler : IRequestHandler<FindPetRequest, List<FindPetResult>>
    {
        private readonly PetsDbContext _dbContext;
        public FindPetHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<List<FindPetResult>> Handle(FindPetRequest request, CancellationToken cancellationToken)
        {
            IQueryable<PetEntity> petQuery = _dbContext.Pet;
            if (!String.IsNullOrEmpty(request.UsuarioId))
                petQuery = petQuery.Where(p => p.UsuarioId == request.UsuarioId);

            if (!String.IsNullOrEmpty(request.Termo))
                petQuery = petQuery.Where(p => p.Nome.Contains(request.Termo));

            if (!String.IsNullOrEmpty(request.Raca))
                petQuery = petQuery.Where(p => p.Raca == request.Raca);

            if (!String.IsNullOrEmpty(request.Especie))
                petQuery = petQuery.Where(p => p.Especie == request.Especie);


            var result = petQuery.Select(r => new FindPetResult
            {
                Id = r.Id,
                Nome = r.Nome,
                Especie = r.Especie,
                Raca = r.Raca,
                Sexo = r.Sexo,
                UsuarioId = r.UsuarioId,
                DataNascimento = r.DataNascimento,
                Descricao = r.Descricao,
                Imagem = null
            }).ToList();
            return Task.FromResult(result);
        }
    }
}
