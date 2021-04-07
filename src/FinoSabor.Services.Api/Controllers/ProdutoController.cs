using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels.Frete;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Cliente
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador, IAspNetUser appUser,
                                 ICategoriaRepository categoriaRepository,
                                 IProdutoRepository produtoRepository,
                                 IProdutoService produtoService,
                                 IMapper mapper) : base(notificador, appUser)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterTodos()
        {
            return await _produtoRepository.ObterProdutosCliente();
        }

        /*[HttpPost]
        public async Task<ActionResult> CalcularFrete(int cepDestino)
        {
            try
            {
                //Verifica se existe no Frete o calculo para o mesmo CEP e produtos.
                Frete frete = null;//_cookieFrete.Consultar().Where(a => a.CEP == cepDestino && a.CodCarrinho == GerarHash(_cookieCarrinhoCompra.Consultar())).FirstOrDefault();
                if (frete != null)
                {
                    return Ok(frete);
                }
                else
                {

                    List<ProdutoItem> produtos = CarregarProdutoDB();
                    List<Pacote> pacotes = _calcularPacote.CalcularPacotesDeProdutos(produtos);

                    ValorPrazoFrete valorPAC = await _wscorreios.CalcularFrete(cepDestino.ToString(), TipoFreteConstant.PAC, pacotes);
                    ValorPrazoFrete valorSEDEX = await _wscorreios.CalcularFrete(cepDestino.ToString(), TipoFreteConstant.SEDEX, pacotes);
                    ValorPrazoFrete valorSEDEX10 = await _wscorreios.CalcularFrete(cepDestino.ToString(), TipoFreteConstant.SEDEX10, pacotes);

                    List<ValorPrazoFrete> lista = new List<ValorPrazoFrete>();
                    if (valorPAC != null) lista.Add(valorPAC);
                    if (valorSEDEX != null) lista.Add(valorSEDEX);
                    if (valorSEDEX10 != null) lista.Add(valorSEDEX10);

                    frete = new Frete()
                    {
                        CEP = cepDestino,
                        CodCarrinho = GerarHash(_cookieCarrinhoCompra.Consultar()),
                        ListaValores = lista
                    };

                    return Ok(frete);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "CarrinhoCompraControler > CalcularFrete");
                return BadRequest(e);
            }
        }*/

        [HttpGet("{slug}")]
        public async Task<ActionResult<ProdutoClienteViewModel>> ObterPorId(string slug)
        {
            return await _produtoRepository.ObterProdutoPorSlug(slug);

        }

    }
}
