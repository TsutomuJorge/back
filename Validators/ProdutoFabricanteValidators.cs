using Entities.DTO;
using Utils.Exceptions;
using Utils.Messages;

namespace Validators
{
    public static class ProdutoFabricanteValidators
    {
        public static void Validar(ProdutoFabricanteDTO produtoFabricanteDTO, List<string>? excecoesIniciais)
        {
            var excecoes = excecoesIniciais ?? new List<string>();

            ValidarCamposObrigatorios(produtoFabricanteDTO, excecoes);
            ValidarCamposDecimais(produtoFabricanteDTO, excecoes);

            if (excecoes.Count > 0)
            {
                var excecoesAgrupadas = excecoes.Distinct().ToList();
                throw new CustomException(excecoesAgrupadas);
            }
        }

        public static bool ValidarCampos(ProdutoFabricanteDTO produtoFabricanteDTO)
        {
            var excecoes = new List<string>();

            ValidarCamposDecimais(produtoFabricanteDTO, excecoes);
            ValidarCamposObrigatorios(produtoFabricanteDTO, excecoes);

            return excecoes.Any();
        }

        private static void ValidarCamposObrigatorios(ProdutoFabricanteDTO produtoFabricanteDTO, List<string> excecoes)
        {
            if (string.IsNullOrEmpty(produtoFabricanteDTO.NomeFabricante))
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_002, BaseValidator.ObterNomePropriedade(() => produtoFabricanteDTO.NomeFabricante)));
            }
            if (string.IsNullOrEmpty(produtoFabricanteDTO.DescricaoProduto))
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_002, BaseValidator.ObterNomePropriedade(() => produtoFabricanteDTO.DescricaoProduto)));
            }
        }

        private static void ValidarCamposDecimais(ProdutoFabricanteDTO produtoFabricanteDTO, List<string> excecoes)
        {
            if (produtoFabricanteDTO.CustoUnitario == 0)
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_003, BaseValidator.ObterNomePropriedade(() => produtoFabricanteDTO.CustoUnitario)));
            }
            if (produtoFabricanteDTO.ValorUnitario == 0)
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_003, BaseValidator.ObterNomePropriedade(() => produtoFabricanteDTO.ValorUnitario)));
            }
        }


    }
}
