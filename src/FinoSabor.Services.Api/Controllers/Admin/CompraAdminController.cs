using AutoMapper;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Admin
{
    [AllowAnonymous]
    [Route("api/Admin/Compra")]
    public class CompraAdminController : MainController
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public CompraAdminController(ICompraService compraService,
                                     IMapper mapper)
        {
            _compraService = compraService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IEnumerable<CompraViewModel>> ObterTodos()
        {
            return await _compraService.ObterTodos();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompraDetalhadaViewModel>> ObterPorId(Guid id)
        {
            var produto = await _compraService.ObterPorId(id);

            return produto is null ? NotFound() : CustomResponseAsync(produto);
        }


        [HttpPost]
        public async Task<ActionResult<CompraAddViewModel>> Adicionar(CompraAddViewModel compraAddViewModel)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _compraService.Adicionar(_mapper.Map<Compra>(compraAddViewModel)));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(CompraAddViewModel compraAddViewModel)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _compraService.Atualizar(_mapper.Map<Compra>(compraAddViewModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            return CustomResponseAsync(await _compraService.Remover(id));
        }

    }
}
