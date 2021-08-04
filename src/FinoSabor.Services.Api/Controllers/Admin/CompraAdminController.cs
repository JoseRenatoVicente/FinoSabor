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
using AutoMapper;

namespace FinoSabor.Services.Api.Controllers.Admin
{
    [AllowAnonymous]
    [Route("api/Admin/Compra")]
    public class CompraAdminController : MainController
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public CompraAdminController(INotificador notificador, IAspNetUser appUser,
                                     ICompraService compraService,
                                     IMapper mapper) : base(notificador, appUser)
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

            return produto is null ? NotFound() : CustomResponse(produto);
        }

        
        [HttpPost]
        public async Task<ActionResult<CompraAddViewModel>> Adicionar(CompraAddViewModel compraAddViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _compraService.Adicionar(_mapper.Map<Compra>(compraAddViewModel)));
        }
        
       [HttpPut]
        public async Task<IActionResult> Atualizar(CompraAddViewModel compraAddViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _compraService.Atualizar(_mapper.Map<Compra>(compraAddViewModel)));
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            return CustomResponse(await _compraService.Remover(id));
        }

    }
}
