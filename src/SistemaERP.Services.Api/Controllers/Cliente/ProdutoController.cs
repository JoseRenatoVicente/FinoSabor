using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.ViewModels.Cliente;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers.Cliente
{
    [AllowAnonymous]
    [Route("api/Cliente/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador, IAspNetUser appUser,
                                 ICategoriaRepository categoriaRepository,
                                 IProdutoRepository produtoRepository,
                                 IMapper mapper) : base(notificador, appUser)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<ProdutoClienteViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoClienteViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoClienteViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await _produtoRepository.ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return _mapper.Map<ProdutoClienteViewModel>(produtoViewModel);
        }

    }
}
