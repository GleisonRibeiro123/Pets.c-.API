using Pets.Core.Query.Contracts.Usuario.Results;
using System;

namespace Pets.Core.Query.Contracts.Amizade.Results
{
    public class FindSolicitacaoResult
    {
        public string Id { get; set; }
        public UsuarioModel Solicitante { get; set; }
        public UsuarioModel Solicitado { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
