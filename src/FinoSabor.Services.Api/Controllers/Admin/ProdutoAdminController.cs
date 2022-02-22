using AutoMapper;
using DinkToPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Relatorio;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FinoSabor.Domain.Helpers;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Admin/Produto")]
    public class ProdutoAdminController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly IRelatorioService _relatorioService;


        public ProdutoAdminController(INotificador notificador,
                                  IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IRelatorioService relatorioService,
                                  IMapper mapper,
                                  IAspNetUser user) : base(notificador, user)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
            _relatorioService = relatorioService;
        }


        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
   /*     [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return await _produtoService.ObterProdutos();
        }
   */
        [HttpGet]
        public async Task<PagedList<ProdutoViewModel>> ObterTodos(int PagNumero = 1, int PagRegistro = 10, string busca = null)
        {
            return await _produtoService.ObterProdutos(PagNumero, PagRegistro, busca);
        }

        /// <summary>
        /// Retrieves a specific product by unique id
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">The product id</param>
        /// <response code="200">Product created</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your product right now</response>

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            return await _produtoService.ObterProdutosPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoInsertViewModel>> Adicionar(ProdutoInsertViewModel produtoViewModel)
        {
            produtoViewModel.Id = Guid.NewGuid();
            var produto = await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            if (produto)
            {
                return Ok(produtoViewModel);
            }
            return CustomResponse(produto);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ProdutoInsertViewModel produtoViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            return CustomResponse(await _produtoService.Remover(id));
        }

        [HttpPost("tornarImagemPrincipal/{caminhoImagem}")]
        public async Task<ActionResult> AdicionarImagemProduto(string caminhoImagem)
        {
            return CustomResponse(await _produtoService.MudarImagemPrincipal(caminhoImagem));
        }

        [HttpPost("uploadImage/{id:guid}")]
        public async Task<ActionResult> AdicionarImagemProduto(Guid id, IFormFile file, bool ImagemPrincipal = false)
        {
            return CustomResponse(await _produtoService.AdicionarImagem(id, file, ImagemPrincipal));
        }

        [HttpDelete("deleteImage{caminhoImagem}")]
        public async Task<ActionResult<ProdutoViewModel>> ExcluirImagem(string caminhoImagem)
        {
            return CustomResponse(await _produtoService.RemoverImagem(caminhoImagem));
        }

        [HttpGet("relatorio")]
        public async Task<IActionResult> CreatePDF()
        {
            try
            {


                GlobalSettings optionalGlobalSettings = new()
                {
                    DocumentTitle = "Relatório dos Produtos"
                };
                ObjectSettings objectSettings = new()
                {
                    HtmlContent = await GetHTMLString(),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Página [page] de [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };

                return File(await _relatorioService.CreatePDF(optionalGlobalSettings, objectSettings), "application/pdf");
            }
            catch (Exception exception)
            {
                NotificarErro(exception +"");
                return CustomResponse(); 
            }
        }

        private async Task<string> GetHTMLString()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Relatório dos Produtos</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Nome</th>
                                        <th>Descrição</th>
                                        <th>Valor</th>
                                        <th>Ativo</th>
                                        <th>Altura</th>
                                        <th>Peso</th>
                                        <th>Comprimento</th>
                                        <th>Quantidade em Estoque</th>
                                        <th>Quantidade em Minima</th>
                                    </tr>");
            foreach (var pro in produtos)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                  </tr>", pro.Nome, pro.Descricao, pro.Valor, pro.Ativo, pro.QuantidadeEstoque, pro.QuantidadeMinima);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }



    }
}
