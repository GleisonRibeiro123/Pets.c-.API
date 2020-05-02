using System.ComponentModel.DataAnnotations;

namespace Pets.Core.Query.Context.Entities
{
    public class ImagemEntity
    {
        [Key]
        public string Id { get; set; }
        public byte[] Imagem { get; set; }
    }
}
