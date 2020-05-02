using System;

namespace Pets.Core.Query.Contracts.Pet.Results
{
    public class GetPetResult
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Raca { get; set; }
        public byte[] Imagem { get; set; }
    }
}
