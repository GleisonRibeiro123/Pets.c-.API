using MediatR;
using Pets.Core.Query.Context;
using Pets.Core.Query.Context.Entities;
using Pets.Core.Query.Contracts.Usuario.Results;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pets.Core.Query.Usuario.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioRequest, AdicionarUsuarioResult>
    {
        private readonly PetsDbContext _dbContext;
        public UsuarioCommandHandler(PetsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
        }

        public Task<AdicionarUsuarioResult> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            _dbContext.Usuario.Add(new UsuarioEntity
            {
                Id = request.Id,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                Imagem = request.Imagem,
                DataNascimento = request.DataNascimento,
                Descricao = request.Descricao
            });

            _dbContext.SaveChanges();

            var usuarioSalvo = _dbContext.Usuario.Single(u => u.Id == request.Id);
            return Task.FromResult(new AdicionarUsuarioResult
            {
                Id = usuarioSalvo.Id,
                Nome = usuarioSalvo.Nome,
                Email = usuarioSalvo.Email,
                Telefone = usuarioSalvo.Telefone,
                Imagem = usuarioSalvo.Imagem,
                DataNascimento = usuarioSalvo.DataNascimento,
                Descricao = usuarioSalvo.Descricao
            });
        }
    }
}
