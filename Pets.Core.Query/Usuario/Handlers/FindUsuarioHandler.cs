using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Usuario.Results;
using Pets.Core.Query.Usuario.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Usuario.Handlers
{
    public class FindUsuarioHandler : IRequestHandler<FindUsuarioRequest, List<FindUsuarioResult>>
    {
        private readonly PetsDbContext _dbContext;
        public FindUsuarioHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }

        public Task<List<FindUsuarioResult>> Handle(FindUsuarioRequest request, CancellationToken cancellationToken)
        {
            IQueryable<UsuarioEntity> usuarioQuery = _dbContext.Usuario;
            if (!String.IsNullOrEmpty(request.Termo))
            {
                usuarioQuery = usuarioQuery.Where(u => u.Nome.Contains(request.Termo) || u.Email.Contains(request.Termo) || u.Telefone.Contains(request.Termo));
            }

            var result = usuarioQuery.Select(r => new FindUsuarioResult
            {
                Id = r.Id,
                Nome = r.Nome,
                Email = r.Email,
                Telefone = r.Telefone,
                DataNascimento = r.DataNascimento,
                Descricao = r.Descricao,
                Imagem = null
            }).ToList();
            return Task.FromResult(result);
        }
    }
}
