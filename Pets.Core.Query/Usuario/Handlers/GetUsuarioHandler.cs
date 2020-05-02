using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Contracts.Usuario.Results;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Usuario.Handlers
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioRequest, GetUsuarioResult>
    {
        private readonly PetsDbContext _dbContext;
        public GetUsuarioHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }
        public Task<GetUsuarioResult> Handle(GetUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = _dbContext.Usuario.Single(u => u.Id == request.UsuarioId);
            return Task.FromResult(new GetUsuarioResult
            {
                Id = usuario.Id,
                DataNascimento = usuario.DataNascimento,
                Descricao = usuario.Descricao,
                Email = usuario.Email,
                Imagem = usuario.Imagem,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone
            });
        }
    }
}
