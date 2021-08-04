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
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador, IAspNetUser appUser,
                                 IProdutoRepository produtoRepository,
                                 IProdutoService produtoService,
                                 IMapper mapper) : base(notificador, appUser)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterTodos()
        {
            return await _produtoRepository.ObterProdutosCliente();
        }

        /*[HttpGet("catalogo/")]
        public async Task<PagedResult<Produto>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            return await _produtoRepository.ObterTodos(ps, page, q);
        }*/

        [HttpGet("{slug}")]
        public async Task<ActionResult<ProdutoClienteViewModel>> ObterPorId(string slug)
        {
            return await _produtoRepository.ObterProdutoPorSlug(slug);

        }


        [HttpGet("lista/{ids}")]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosPorId(string ids)
        {
            return await _produtoRepository.ObterProdutosPorIds(ids);
        }

    }
}
