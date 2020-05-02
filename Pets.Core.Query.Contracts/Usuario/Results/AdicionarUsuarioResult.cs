using System;

namespace Pets.Core.Query.Contracts.Usuario.Results
{
    public class AdicionarUsuarioResult
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
    }
}
