using System;
using System.ComponentModel.DataAnnotations;

namespace Pets.Core.Query.Context.Entities
{
    public class PetEntity
    {
        [Key]
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Raca { get; set; }
    }
}
