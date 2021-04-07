using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
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

        public CompraAdminController(INotificador notificador, IAspNetUser appUser,
                                     ICompraService compraService) : base(notificador, appUser)
        {
            _compraService = compraService;
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
        public async Task<ActionResult<CompraViewModel>> ObterPorId(Guid id)
        {
            return await _compraService.ObterPorId(id);
        }

        /*
        [HttpPost]
        public async Task<ActionResult<ProdutoInsertViewModel>> Adicionar(ProdutoInsertViewModel produtoViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel)));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(ProdutoInsertViewModel produtoViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel)));
        }
        */

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            return CustomResponse(await _compraService.Remover(id));
        }


    }
}
