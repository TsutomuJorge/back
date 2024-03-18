using Entities.DTO;

namespace Entities.Entities
{
    public class Produto : EntidadeBase
    {
        public Produto()
        {

        }

        public Produto(string descricao) {
            Descricao = descricao;
        }

        public Produto(ProdutoDTO dto)
        {
            Id = dto.Id;
            Descricao = dto.Descricao;
        }

        public string Descricao { get; set; }
    }
}
