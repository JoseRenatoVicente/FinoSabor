using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    public class PedidoController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(INotificador notificador, IAspNetUser appUser,
                                IPedidoRepository pedidoRepository) : base(notificador, appUser)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pedido>> ObterTodos()
        {
            return CustomResponse(await _pedidoRepository.GetAllAsync());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Pedido>> ObterPorId(Guid id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);

            if (pedido == null) return NotFound();

            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Adicionar(Pedido pedido)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //pedido.id = Guid.NewGuid();

            await _pedidoRepository.AddAsync(pedido);

            return CustomResponse(pedido);
        }


    }
}
