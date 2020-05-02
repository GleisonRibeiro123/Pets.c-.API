using MediatR;
using Pets.Core.Query.Amizade.Requests;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Amizade.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Amizade.Handlers
{
    public class SolicitacaoCommandHandler : IRequestHandler<SolicitarAmizadeRequest, SolicitarAmizadeResult>,
                                             IRequestHandler<ResponderSolicitacaoRequest, ResponderSolicitacaoResult>
    {
        private readonly PetsDbContext _dbContext;
        public SolicitacaoCommandHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<SolicitarAmizadeResult> Handle(SolicitarAmizadeRequest request, CancellationToken cancellationToken)
        {
            _dbContext.SolicitacaoAmizade.Add(new SolicitacaoAmizadeEntity
            {
                Id = request.Id,
                SolicitadoId = request.SolicitadoId,
                SolicitanteId = request.SolicitanteId,
                DataSolicitacao = DateTime.Now
            });
            _dbContext.SaveChanges();

            var solicitacaoSalva = _dbContext.SolicitacaoAmizade.Single(s => s.Id == request.Id);
            return Task.FromResult(new SolicitarAmizadeResult
            {
                Id = solicitacaoSalva.Id,
                SolicitadoId = solicitacaoSalva.SolicitadoId,
                SolicitanteId = solicitacaoSalva.SolicitanteId,
                DataSolicitacao = solicitacaoSalva.DataSolicitacao
            });
        }

        public Task<ResponderSolicitacaoResult> Handle(ResponderSolicitacaoRequest request, CancellationToken cancellationToken)
        {
            var solicitacao = _dbContext.SolicitacaoAmizade.Single(s => s.Id == request.SolicitacaoId);

            if (request.Adicionado)
            {
                _dbContext.VinculoAmizade.Add(new VinculoAmizadeEntity
                {
                    SolicitanteId = solicitacao.SolicitadoId,
                    SolicitadoId = solicitacao.SolicitanteId,
                    DataConfirmacao = DateTime.Now,
                    DataSolicitacao = solicitacao.DataSolicitacao
                });
                _dbContext.SolicitacaoAmizade.Remove(solicitacao);
            }
            else
                _dbContext.SolicitacaoAmizade.Remove(solicitacao);

            _dbContext.SaveChanges();

            return Task.FromResult(new ResponderSolicitacaoResult
            {
                Aceito = request.Adicionado
            });
        }
    }
}
