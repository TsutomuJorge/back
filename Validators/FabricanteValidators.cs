using Entities.DTO;
using Utils.Exceptions;
using Utils.Messages;

namespace Validators
{
    public static class FabricanteValidators
    {
        public static void Validar(FabricanteDTO fabricanteDTO, List<string>? excecoesIniciais)
        {
            var excecoes = excecoesIniciais ?? new List<string>();

            ValidarCamposObrigatorios(fabricanteDTO, excecoes);

            if (excecoes.Count > 0)
            {
                var excecoesAgrupadas = excecoes.Distinct().ToList();
                throw new CustomException(excecoesAgrupadas);
            }
        }

        public static bool ValidarCampos(FabricanteDTO fabricanteDTO)
        {
            var excecoes = new List<string>();

            ValidarCamposObrigatorios(fabricanteDTO, excecoes);

            return excecoes.Any();
        }

        private static void ValidarCamposObrigatorios(FabricanteDTO fabricanteDTO, List<string> excecoes)
        {
            if (string.IsNullOrEmpty(fabricanteDTO.Nome))
            {
                excecoes.Add(string.Format(MessagesAPI.RS_MENS_002, BaseValidator.ObterNomePropriedade(() => fabricanteDTO.Nome)));
            }
        }
    }
}
