using Entities.DTO;

namespace Entities.Entities
{
    public class Fabricante : EntidadeBase
    {
        public Fabricante()
        {

        }

        public Fabricante(string nome)
        {
            Nome = nome;
        }

        public Fabricante(FabricanteDTO dto)
        {
            Id = dto.Id;
            Nome = dto.Nome;
        }

        public string Nome { get; set; }
    }
}
