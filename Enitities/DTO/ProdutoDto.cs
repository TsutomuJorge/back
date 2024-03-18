using Entities.Entities;

namespace Entities.DTO
{
    public class ProdutoDTO
    {
        public ProdutoDTO()
        {

        }

        public ProdutoDTO(Produto entitie)
        {
            Id = entitie.Id;
            Descricao = entitie.Descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
