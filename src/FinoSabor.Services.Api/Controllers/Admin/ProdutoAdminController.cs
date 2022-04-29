using DinkToPdf;
using FinoSabor.Application.Imagem.Commands;
using FinoSabor.Application.Produtos.Commands.AdicionarProduto;
using FinoSabor.Application.Produtos.Commands.AtualizarProduto;
using FinoSabor.Application.Produtos.Commands.RemoverProduto;
using FinoSabor.Application.Produtos.Queries;
using FinoSabor.Application.Relatorio;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities.Identity;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.Mediator;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Admin/Produto")]
    public class ProdutoAdminController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IProdutoQueries _produtoQueries;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IRelatorioService _relatorioService;

        public ProdutoAdminController(IMediatorHandler mediator, IProdutoQueries produtoQueries, IRelatorioService relatorioService, IProdutoRepository produtoRepository)
        {
            _mediator = mediator;
            _produtoQueries = produtoQueries;
            _produtoRepository = produtoRepository;
            _relatorioService = relatorioService;
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<PagedList<ProdutoViewModel>> ObterTodos(int PagNumero = 1, int PagRegistro = 10, string busca = null)
        {
            return await _produtoQueries.ObterProdutos(PagNumero, PagRegistro, busca);
        }

        /// <summary>
        /// Retorna um produto específico através de seu Id que é único
        /// </summary>
        /// <remarks>Retorna um produto específico através de seu Id que é único</remarks>
        /// <param name="id" example="3fa85f64-5717-4562-b3fc-2c963f66afa6">The product id</param>
        /// <response code="200">Sucesso</response>
        /// <response code="400">O produto tem valores ausentes/inválidos</response>
        /// <response code="500">Erro ao retornar produto</response>

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            return await _produtoQueries.ObterProdutosPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult> Adicionar(AdicionarProdutoCommand adicionarProdutoCommand)
        {

            //Produto produto = await _mediator.Send(new ObterPorId(produtoViewModel.Id));
            return CustomResponseAsync(await _mediator.Send(adicionarProdutoCommand));

            /*var produto = await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            if (produto)
            {
                return Ok(produtoViewModel);
            }
            return CustomResponse(produto);*/
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(AtualizarProdutoCommand atualizarProdutoCommand)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _mediator.Send(atualizarProdutoCommand));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(RemoverProdutoCommand removerProdutoCommand)
        {
            return CustomResponseAsync(await _mediator.Send(removerProdutoCommand));
        }
        [HttpPost("uploadImage/{id:guid}")]
        public async Task<ActionResult> AdicionarImagemProduto(Guid id, IFormFile file, bool imagemPrincipal = false)
        {
            return CustomResponseAsync(await _mediator.Send(new AdicionarImagemCommand(id, file, imagemPrincipal)));
        }

        [HttpPost("tornarImagemPrincipal/{caminhoImagem}")]
        public async Task<ActionResult> TornarImagemPrincipal(string caminhoImagem)
        {
            return CustomResponseAsync(await _mediator.Send(new MudarImagemPrincipalCommand(caminhoImagem)));
        }


        [HttpDelete("deleteImage{caminhoImagem}")]
        public async Task<ActionResult<ProdutoViewModel>> ExcluirImagem(string caminhoImagem)
        {
            return CustomResponseAsync(await _mediator.Send(new RemoverImagemCommand(caminhoImagem)));
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
                AddError(exception + "");
                return CustomResponseAsync();
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
