using System;

namespace Pets.Core.Query.Contracts.Amizade.Results
{
    public class SolicitarAmizadeResult
    {
        public string Id { get; set; }
        public string SolicitanteId { get; set; }
        public string SolicitadoId { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
