using System.ComponentModel.DataAnnotations;

namespace Pets.Core.Query.Context.Entities
{
    public class FeedEntity
    {
        [Key]
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string PayloadType { get; set; }
        public string Payload { get; set; }
    }
}
