namespace Pets.Core.Query.Contracts.Pet.Queries
{
    public class FindPet
    {
        public string UsuarioId { get; set; }
        public string Termo { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
    }
}
