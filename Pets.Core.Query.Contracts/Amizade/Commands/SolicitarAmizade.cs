using System;

namespace Pets.Core.Query.Contracts.Amizade.Commands
{
    public class SolicitarAmizade
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string SolicitanteId { get; set; }
        public string SolicitadoId { get; set; }
    }
}
