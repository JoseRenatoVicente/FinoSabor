using AutoMapper;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Domain.ViewModels.Cliente.Pedido;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [Route("api/[controller]")]
    public class PedidoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPedidoService _pedidoService;
        private readonly IAspNetUser _user;

        public PedidoController(IAspNetUser user,
                                IMapper mapper,
                                IPedidoService pedidoService)
        {
            _user = user;
            _mapper = mapper;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> ObterPedidosDoUsuario()
        {
            return await _pedidoService.ObterPedidosDoUsuario(_user.ObterUserId());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoDetalhadoViewModel>> ObterPorId(Guid id)
        {
            var pedido = await _pedidoService.ObterPedidoDoUsuarioPorId(id, _user.ObterUserId());

            if (pedido is null) return NoContent();

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDetalhadoViewModel>> Adicionar(PedidoInsertViewModel pedido)
        {
            if (!ModelState.IsValid) return CustomResponseAsync(ModelState);
            pedido.Id = Guid.NewGuid();
            pedido.id_usuario = _user.ObterUserId();

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedido));

            return CustomResponseAsync(await ObterPorId(pedido.Id));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(PedidoInsertViewModel pedido)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedido), _user.ObterUserId()));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            return CustomResponseAsync(await _pedidoService.Remover(id, _user.ObterUserId()));
        }

    }
}
