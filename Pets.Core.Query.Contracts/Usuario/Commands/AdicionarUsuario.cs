using System;

namespace Pets.Core.Query.Contracts.Usuario.Commands
{
    public class AdicionarUsuario
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
    }
}
