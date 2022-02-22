using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Entities.Enums;
using FinoSabor.Domain.Validations;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository,
            IProdutoRepository produtoRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterPedidosDoUsuario(Guid id_usuario)
        {
            return await (await _pedidoRepository.GetAllAsync())
                .Where(c => c.IdUsuario == id_usuario)
                .ProjectTo<PedidoViewModel>(_mapper.ConfigurationProvider)
                .OrderByDescending(c => c.data_pedido).ToListAsync();
        }
        public async Task<PedidoDetalhadoViewModel> ObterPedidoDoUsuarioPorId(Guid id, Guid id_usuario)
        {
            return await (await _pedidoRepository.GetAllAsync())
            .ProjectTo<PedidoDetalhadoViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id && x.id_usuario == id_usuario);
        }

        public async Task<IEnumerable<PedidoViewModel>> ObterTodosOsPedidos()
        {
            return await (await _pedidoRepository.GetAllAsync())
                 .ProjectTo<PedidoViewModel>(_mapper.ConfigurationProvider).OrderByDescending(c => c.data_pedido).ToListAsync();
        }

        public async Task<PedidoDetalhadoViewModel> ObterPorId(Guid id)
        {
            return await (await _pedidoRepository.GetAllAsync())
            .ProjectTo<PedidoDetalhadoViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id);
        }


        /*public async Task<CompraDetalhadaViewModel> ObterPorId(Guid id)
        {
            return await (await _pedidoRepository.GetAllAsync())
            .ProjectTo<CompraDetalhadaViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.id == id);
        }*/

        public async Task<bool> Adicionar(Pedido pedido)
        {
            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return false;

            foreach (var item in pedido.Itens)
            {
                if (!ExecutarValidacao(new Itens_PedidoValidation(), item)) return false;
            }

            pedido.Status = StatusPedido.EmAndamento;

            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(item.IdProduto);
                if (produto is null || produto.QuantidadeEstoque <= 0)
                {
                    Notificar("Produto não pode ser adicionado");
                    return false;
                }

                item.IdPedido = pedido.Id;
                item.ValorUnitario = produto.Valor;


                produto.QuantidadeEstoque -= item.Quantidade;

                await _produtoRepository.UpdateAsync(produto);
            }

            await _pedidoRepository.AddAsync(pedido);
            return true;
        }

        public async Task<bool> Atualizar(Pedido pedido, Guid id_usuario)
         {          

            if (!ExecutarValidacao(new PedidoValidation(), pedido)) return false;

            foreach (var item in pedido.Itens)
            {
                if (!ExecutarValidacao(new Itens_PedidoValidation(), item)) return false;
            }


            var pedidoBD = await _pedidoRepository.GetByIdAsync(pedido.Id);
            if (pedidoBD is null || pedidoBD.IdUsuario != id_usuario)
            {
                Notificar("Pedido não encontrado");
                return false;
            }


            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(item.IdProduto);
                if (produto is null || produto.QuantidadeEstoque <= 0 || item.Quantidade > produto.QuantidadeEstoque)
                {
                    Notificar("Produto não pode ser adicionado");
                    return false;
                }

                item.IdPedido = pedido.Id;
                item.ValorUnitario = produto.Valor;


                produto.QuantidadeEstoque -= item.Quantidade;

                await _produtoRepository.UpdateAsync(produto);
            }

            await _pedidoRepository.UpdateAsync(pedido);
            return true;
        }

        public async Task<bool> Remover(Guid id_pedido, Guid id_usuario)
        {
            var pedido = await ObterPorId(id_pedido);
            if (pedido is null || pedido.status != StatusPedido.EmAndamento || pedido.id_usuario != id_usuario)
            {
                Notificar("O pedido não pode ser excluido");
                return false;
            }

            foreach (var item in pedido.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(item.id_produto);

                produto.QuantidadeEstoque =
                    produto.QuantidadeEstoque <= 0 ? 0 : produto.QuantidadeEstoque += item.quantidade;

                await _produtoRepository.UpdateAsync(produto);
            }

            await _pedidoRepository.DeleteAsync(id_pedido);
            return true;
        }

        public void Dispose()
        {
            _pedidoRepository?.Dispose();
            _produtoRepository?.Dispose();
        }
    }
}
