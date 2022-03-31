using AutoMapper;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Admin
{
    [AllowAnonymous]
    [Route("api/Admin/Pedido")]
    public class PedidoAdminController : MainController
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;
        public PedidoAdminController(IMapper mapper,
                                     IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> ObterTodosOsPedidos()
        {
            return await _pedidoService.ObterTodosOsPedidos();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoDetalhadoViewModel>> ObterPorId(Guid id)
        {
            return await _pedidoService.ObterPorId(id);
        }
        /*
        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel)));
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Atualizar(Categoria categoria)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoriaService.Atualizar(categoria));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Categoria>> Excluir(Guid id)
        {
            return CustomResponse(await _categoriaService.Remover(id));
        }
        */
    }
}
