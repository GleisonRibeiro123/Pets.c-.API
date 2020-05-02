using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pets.Core.Query.Context.Entities
{
    public class SolicitacaoAmizadeEntity
    {
        [Key]
        public string Id { get; set; }
        public string SolicitanteId { get; set; }
        public string SolicitadoId { get; set; }
        public DateTime DataSolicitacao { get; set; }
        [ForeignKey("SolicitanteId")]
        public UsuarioEntity Solicitante { get; set; }
        [ForeignKey("SolicitadoId")]
        public UsuarioEntity Solicitado { get; set; }
    }
}
