using Entities.DTO;
using Entities.Entities;
using IBusiness.IBusiness;
using IRepository.IRepositories;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Utils.Extensions;
using Validators;

namespace Business.Business
{
    public class ProdutoFabricanteBusiness : BaseBusiness<ProdutoFabricante>, IProdutoFabricanteBusiness
    {
        private readonly IFabricanteBusiness _fabricanteBusiness;
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IProdutoFabricanteRepository _repository;

        public ProdutoFabricanteBusiness(IProdutoFabricanteRepository repository,
            IFabricanteBusiness fabricanteBusiness,
            IProdutoBusiness produtoBusiness) : base(repository)
        {
            _fabricanteBusiness = fabricanteBusiness;
            _produtoBusiness = produtoBusiness;
            _repository = repository;
        }

        public async Task<List<ProdutoFabricanteDTO>> ConsultarProdutosFabricantes(bool asNoTracking = false)
        {
            var produtosFabricantes = await base.GetAll(asNoTracking);
            var produtosFabricantesDTO = new List<ProdutoFabricanteDTO>();

            produtosFabricantes.ForEach(x => produtosFabricantesDTO.Add(new ProdutoFabricanteDTO(x)));
            return produtosFabricantesDTO;
        }

        public override async Task<ProdutoFabricante> Add(ProdutoFabricante entidade)
        {
            await PreencherDadosProdutoEFabricante(entidade);

            var produtoFabricante = await _repository.ObterProdutoFabricantePorIdProdutoIdFabricante(entidade.IdProduto, entidade.IdFabricante);
    
            if (produtoFabricante.IsNull())
            {
                VerificarSeProdutoEFabricanteExistemAoAdicionar(entidade);
                return await base.Add(entidade);
            } else
            {
                entidade.Id = produtoFabricante.Id;
                return await base.Update(entidade, true);
            }
        }

        private static void VerificarSeProdutoEFabricanteExistemAoAdicionar(ProdutoFabricante entidade)
        {
            if (entidade.Fabricante.Id > 0)
            {
                entidade.Fabricante = null;
            }
            if (entidade.Produto.Id > 0)
            {
                entidade.Produto = null;
            }
        }

        public async Task<ProdutoFabricante> Update(ProdutoFabricanteDTO dto)
        {
            var entidade = new ProdutoFabricante(dto);
            await PreencherDadosProdutoEFabricante(entidade);

            return await _repository.Update(entidade, true);
        }

        private async Task PreencherDadosProdutoEFabricante(ProdutoFabricante produtoFabricante)
        {
            var fabricante = await _fabricanteBusiness.ObterFabricantoPorNome(produtoFabricante.Fabricante.Nome);
            var produto = await _produtoBusiness.ObterProdutoPorDescricao(produtoFabricante.Produto.Descricao);

            if (fabricante.IsNotNull())
            {
                produtoFabricante.IdFabricante = fabricante.Id;
                produtoFabricante.Fabricante = fabricante;
            }
            else if (produto.IsNotNull())
            {
                produtoFabricante.IdProduto = produto.Id;
                produtoFabricante.Produto = produto;
            }
        }

        public async Task<bool> Delete(ProdutoFabricanteDTO dto)
        {
            var produtoFabricante = await _repository.GetById(dto.Id);

            try
            {
                await _repository.Delete(produtoFabricante, true);
                return true;
            } catch
            {
                return false;
            }           
        }

        public async Task ImportarPlanilha(ArquivoImportadoDTO arquivoImportado)
        {
            var produtosFabricantesDTO = new List<ProdutoFabricanteDTO>();
            var dadosObtidosComSucesso = ObterDadosImportados(arquivoImportado, produtosFabricantesDTO);

            ValidarDadosProdutoFabricante(produtosFabricantesDTO);

            if (dadosObtidosComSucesso)
            {
                var produtosFabricantes = await MontarProdutoFabricanteCasoExistaNoBanco(produtosFabricantesDTO);
                await _repository.AddBulk(produtosFabricantes);
                await _repository.Save();
            }
        }

        private async Task<List<ProdutoFabricante>> MontarProdutoFabricanteCasoExistaNoBanco(List<ProdutoFabricanteDTO> produtosFabricantesDTO)
        {
            await RetirarDadosDuplicados(produtosFabricantesDTO);

            var produtosFabricantesParaAdicionarAoBanco = new List<ProdutoFabricante>();
            var fabricantes = await _fabricanteBusiness.GetAll(true);
            var produtos = await _produtoBusiness.GetAll(true);
            var produtosFabricantes = await _repository.All(true);

            produtosFabricantesDTO.ForEach(produtoFabricanteDTO => {
                var fabricanteEncontrado = fabricantes.FirstOrDefault(x => x.Nome == produtoFabricanteDTO.NomeFabricante.NormalizeSpacesAndCapitalize());
                var produtoEncontrado = produtos.FirstOrDefault(x => x.Descricao == produtoFabricanteDTO.DescricaoProduto.NormalizeSpacesAndCapitalize());
                ProdutoFabricante? produtoFabricanteEncontrado = null;

                if (fabricanteEncontrado.IsNotNull() && produtoEncontrado.IsNotNull())
                {
                    produtoFabricanteEncontrado = produtosFabricantes.FirstOrDefault(x => x.IdFabricante == fabricanteEncontrado.Id && x.IdProduto == produtoEncontrado.Id);
                }
                produtosFabricantesParaAdicionarAoBanco.Add(new ProdutoFabricante(produtoFabricanteDTO, fabricanteEncontrado, produtoEncontrado, produtoFabricanteEncontrado));
            });

            return produtosFabricantesParaAdicionarAoBanco;
        }

        private async Task RetirarDadosDuplicados(List<ProdutoFabricanteDTO> produtosFabricantesDTO)
        {
            var fabricantes = await _fabricanteBusiness.GetAll(true);
            var produtos = await _produtoBusiness.GetAll(true);

            var NomeFabricante = new HashSet<string>(
                produtosFabricantesDTO.Select(x => x.NomeFabricante.NormalizeSpacesAndCapitalize())
            );
            var DescricaoProduto = new HashSet<string>(
                produtosFabricantesDTO.Select(x => x.DescricaoProduto.NormalizeSpacesAndCapitalize())
            );

            var fabricantesParaAdicionar = NomeFabricante.Where(x => !fabricantes.Select(f => f.Nome).Contains(x)).ToList();
            var produtosParaAdicionar = DescricaoProduto.Where(x => !produtos.Select(f => f.Descricao).Contains(x)).ToList();

            await AdicionarFabricantesEProdutosAoBanco(fabricantesParaAdicionar, produtosParaAdicionar);
        }

        private async Task AdicionarFabricantesEProdutosAoBanco(List<string>? nomeFabricantes, List<string>? descricaoProdutos)
        {
            var fabricantes = new List<Fabricante>();
                nomeFabricantes?.ForEach(x => fabricantes.Add(new Fabricante(x)));
            await _fabricanteBusiness.AddBulk(fabricantes);

            var produtos = new List<Produto>();
                descricaoProdutos?.ForEach(x => produtos.Add(new Produto(x)));
            await _produtoBusiness.AddBulk(produtos);
        }

        private static void ValidarDadosProdutoFabricante(List<ProdutoFabricanteDTO> produtosFabricantesDTO)
        {
            var excecoes = new List<string>();

            produtosFabricantesDTO.ForEach(produtoFabricanteDTO => {
                ProdutoFabricanteValidators.Validar(produtoFabricanteDTO, excecoes);
            });
        }

        private static bool ObterDadosImportados(ArquivoImportadoDTO arquivoImportado, List<ProdutoFabricanteDTO> produtosFabricantesDTO)
        {
            try
            {
                using (var stream = arquivoImportado.Arquivo.OpenReadStream())
                {
                    IWorkbook workbook = new XSSFWorkbook(stream);

                    ISheet sheet = workbook.GetSheetAt(0);

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);

                        if (row != null)
                        {
                            IncluirProdutoFabricanteDTO(produtosFabricantesDTO, row);
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void IncluirProdutoFabricanteDTO(List<ProdutoFabricanteDTO> produtosFabricantesDTO, IRow row)
        {
            var produtoFabricanteDTO = new ProdutoFabricanteDTO();
            produtoFabricanteDTO.DescricaoProduto = GetCellValue(row.GetCell(1));
            produtoFabricanteDTO.NomeFabricante = GetCellValue(row.GetCell(2));
            produtoFabricanteDTO.ValorUnitario = Convert.ToDecimal(GetCellValue(row.GetCell(5)));
            produtoFabricanteDTO.CustoUnitario = Convert.ToDecimal(GetCellValue(row.GetCell(9)));

            if (!ProdutoFabricanteValidators.ValidarCampos(produtoFabricanteDTO))
            {
                produtosFabricantesDTO.Add(produtoFabricanteDTO);
            }
        }

        private static string GetCellValue(ICell cell)
        {
            return cell?.ToString();
        }

    }
}
