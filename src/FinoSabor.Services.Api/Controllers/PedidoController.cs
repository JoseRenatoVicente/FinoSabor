using AutoMapper;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Domain.ViewModels.Cliente.Pedido;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
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

        public PedidoController(INotificador notificador, IAspNetUser appUser,
                                IMapper mapper,
                                IPedidoService pedidoService) : base(notificador, appUser)
        {
            _mapper = mapper;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidoViewModel>> ObterPedidosDoUsuario()
        {
            return await _pedidoService.ObterPedidosDoUsuario(AppUser.ObterUserId());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PedidoDetalhadoViewModel>> ObterPorId(Guid id)
        {
            var pedido = await _pedidoService.ObterPedidoDoUsuarioPorId(id, AppUser.ObterUserId());

            if (pedido is null) return NoContent();

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDetalhadoViewModel>> Adicionar(PedidoInsertViewModel pedido)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            pedido.Id = Guid.NewGuid();
            pedido.id_usuario = AppUser.ObterUserId();

            await _pedidoService.Adicionar(_mapper.Map<Pedido>(pedido));

            return CustomResponse(await ObterPorId(pedido.Id));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(PedidoInsertViewModel pedido)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedido), AppUser.ObterUserId()));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            return CustomResponse(await _pedidoService.Remover(id, AppUser.ObterUserId()));
        }

    }
}
