using System;

namespace Pets.Core.Query.Contracts.Pet.Commands
{
    public class AdicionarPet
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Raca { get; set; }
    }
}
