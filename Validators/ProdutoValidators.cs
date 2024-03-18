using Entities.DTO;
using Utils.Exceptions;
using Utils.Messages;

namespace Validators
{
    public static class ProdutoValidators
    {
        public static void Validar(ProdutoDTO produtoDTO, List<string>? excecoesIniciais)
        {
            var excecoes = excecoesIniciais ?? new List<string>();

            ValidarCamposObrigatorios(produtoDTO, excecoes);

            if (excecoes.Count > 0)
            {
                var excecoesAgrupadas = excecoes.Distinct().ToList();
                throw new CustomException(excecoesAgrupadas);
            }
        }

        public static bool ValidarCampos(ProdutoDTO produtoDTO)
        {
            var excecoes = new List<string>();

            ValidarCamposObrigatorios(produtoDTO, excecoes);

            return excecoes.Any();
        }

        private static void ValidarCamposObrigatorios(ProdutoDTO produtoDTO, List<string> excecoes)
        {
            if (string.IsNullOrEmpty(produtoDTO.Descricao))
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_002, BaseValidator.ObterNomePropriedade(() => produtoDTO.Descricao)));
            }
        }
    }
}
