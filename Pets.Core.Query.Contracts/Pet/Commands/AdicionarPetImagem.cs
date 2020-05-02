using System;

namespace Pets.Core.Query.Contracts.Pet.Commands
{
    public class AdicionarPetImagem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PetId { get; set; }
        public string UsuarioTitularId { get; set; }
        public string[] UsuariosDependentesId { get; set; }
        public byte[] Imagem { get; set; }
    }
}
