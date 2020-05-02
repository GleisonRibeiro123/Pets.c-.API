using MediatR;
using Pets.Core.Query.Amizade.Requests;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Amizade.Results;
using Pets.Core.Query.Contracts.Usuario.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Amizade.Handlers
{
    public class FindSolicitacaoHandler : IRequestHandler<FindSolicitacaoRequest, List<FindSolicitacaoResult>>
    {
        private readonly PetsDbContext _dbContext;
        public FindSolicitacaoHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<List<FindSolicitacaoResult>> Handle(FindSolicitacaoRequest request, CancellationToken cancellationToken)
        {
            IQueryable<SolicitacaoAmizadeEntity> solicitacaoQuery = _dbContext.SolicitacaoAmizade;
            if (!string.IsNullOrEmpty(request.UsuarioId))
                solicitacaoQuery = solicitacaoQuery.Where(s => s.SolicitadoId == request.UsuarioId);

            var result = solicitacaoQuery.Select(s => new FindSolicitacaoResult
            {
                Id = s.Id,
                DataSolicitacao = s.DataSolicitacao,
                Solicitado = new UsuarioModel
                {
                    Id = s.Solicitado.Id,
                    DataNascimento = s.Solicitado.DataNascimento,
                    Descricao = s.Solicitado.Descricao,
                    Email = s.Solicitado.Email,
                    Imagem = s.Solicitado.Imagem,
                    Nome = s.Solicitado.Nome,
                    Telefone = s.Solicitado.Telefone
                },
                Solicitante = new UsuarioModel
                {
                    Id = s.Solicitante.Id,
                    DataNascimento = s.Solicitante.DataNascimento,
                    Descricao = s.Solicitante.Descricao,
                    Email = s.Solicitante.Email,
                    Imagem = s.Solicitante.Imagem,
                    Nome = s.Solicitante.Nome,
                    Telefone = s.Solicitante.Telefone
                }
            }).ToList();

            return Task.FromResult(result);
        }
    }
}
