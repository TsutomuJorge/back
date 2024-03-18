using Entities.Entities;

namespace Entities.DTO
{
    public class FabricanteDTO
    {
        public FabricanteDTO()
        {

        }

        public FabricanteDTO(Fabricante entitie)
        {
            Id = entitie.Id;
            Nome = entitie.Nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
