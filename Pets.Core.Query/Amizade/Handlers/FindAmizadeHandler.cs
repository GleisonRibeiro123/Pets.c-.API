using MediatR;
using Pets.Core.Query.Amizade.Requests;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Amizade.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Amizade.Handlers
{
    public class FindAmizadeHandler : IRequestHandler<FindAmizadeRequest, List<FindAmizadeResult>>
    {
        private readonly PetsDbContext _dbContext;
        public FindAmizadeHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<List<FindAmizadeResult>> Handle(FindAmizadeRequest request, CancellationToken cancellationToken)
        {
            List<FindAmizadeResult> result = new List<FindAmizadeResult>();
            IQueryable<VinculoAmizadeEntity> vinculoQuery = _dbContext.VinculoAmizade;

            if (!string.IsNullOrEmpty(request.UsuarioId))
                vinculoQuery = vinculoQuery.Where(v => v.SolicitadoId == request.UsuarioId || v.SolicitanteId == request.UsuarioId);

            if (!string.IsNullOrEmpty(request.Termo))
                vinculoQuery = vinculoQuery.Where(v => v.Solicitado.Nome.Contains(request.Termo)
                || v.Solicitante.Nome.Contains(request.Termo));

            var solicitados = vinculoQuery.Select(v => v.Solicitado);
            var solicitantes = vinculoQuery.Select(v => v.Solicitante);

            foreach (var solicitado in solicitados)
            {
                if (solicitado.Id != request.UsuarioId)
                    result.Add(new FindAmizadeResult
                    {
                        Id = solicitado.Id,
                        Nome = solicitado.Nome,
                        Email = solicitado.Email,
                        Telefone = solicitado.Telefone,
                        DataNascimento = solicitado.DataNascimento,
                        Descricao = solicitado.Descricao,
                        Imagem = null
                    });
            }
            foreach (var solicitante in solicitantes)
            {
                if (solicitante.Id != request.UsuarioId)
                    result.Add(new FindAmizadeResult
                    {
                        Id = solicitante.Id,
                        Nome = solicitante.Nome,
                        Email = solicitante.Email,
                        Telefone = solicitante.Telefone,
                        DataNascimento = solicitante.DataNascimento,
                        Descricao = solicitante.Descricao,
                        Imagem = null
                    });
            }
            return Task.FromResult(result);
        }
    }
}
