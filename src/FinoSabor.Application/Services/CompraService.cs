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
    public class CompraService : BaseService, ICompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public CompraService(INotificador notificador,
                             IMapper mapper,
                             ICompraRepository compraRepository,
                             IProdutoRepository produtoRepository,
                             IFornecedorRepository fornecedorRepository) : base(notificador)
        {
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompraViewModel>> ObterTodos()
        {
           return await (await _compraRepository.GetAllAsync())
                .ProjectTo<CompraViewModel>(_mapper.ConfigurationProvider).OrderByDescending(c => c.data).ToListAsync();
        }
        public async Task<CompraDetalhadaViewModel> ObterPorId(Guid id)
        {
            return await (await _compraRepository.GetAllAsync())
            .ProjectTo<CompraDetalhadaViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<bool> Adicionar(Compra compra)
        {
            if (!ExecutarValidacao(new CompraValidation(), compra)) return false;

            foreach (var item in compra.Itens)
            {
                if (!ExecutarValidacao(new Itens_CompraValidation(), item)) return false;
            }

            if (!await _fornecedorRepository.Existe(c => c.id == compra.id_fornecedor))
            {
                Notificar("Fornecedor não encontrado");
                return false;
            }
            if (compra.status_compra == StatusCompra.Finalizada)
            {
                foreach (var item in compra.Itens)
                {
                    var produto = await _produtoRepository.GetByIdAsync(item.id_produto);
                    if (produto is null)
                    {
                        Notificar("Produto não encontrado");
                        return false;
                    }

                    produto.quantidade_estoque += item.quantidade;

                    await _produtoRepository.UpdateAsync(produto);
                }
            }
            await _compraRepository.AddAsync(compra);
            return true;
        }

        public async Task<bool> Atualizar(Compra compra)
        {
            if (!ExecutarValidacao(new CompraValidation(), compra)) return false;

            foreach (var item in compra.Itens)
            {
                if (!ExecutarValidacao(new Itens_CompraValidation(), item)) return false;
            }

            if (!await _fornecedorRepository.Existe(c => c.id == compra.id_fornecedor))
            {
                Notificar("Fornecedor não encontrado");
                return false;
            }

            var compraBD = await _compraRepository.GetByIdAsync(compra.id);
            if (compraBD is null)
            {
                Notificar("Compra não encontrada");
                return false;
            }

            if (compraBD.status_compra == StatusCompra.Finalizada)
            {
                Notificar("A compra não pode ser atualizada, porque já foi finalizada.");
                return false;
            }


            if (compra.status_compra == StatusCompra.Finalizada)
            {
                foreach (var item in compra.Itens)
                {
                    var produto = await _produtoRepository.GetByIdAsync(item.id_produto);
                    if (produto is null)
                    {
                        Notificar("Produto não encontrado");
                        return false;
                    }

                    produto.quantidade_estoque += item.quantidade;

                    await _produtoRepository.UpdateAsync(produto);
                }
            }

            await _compraRepository.UpdateAsync(compra);

            return true;
        }
        public async Task<bool> Remover(Guid id)
        {
            var compra = await ObterPorId(id);
            if (compra is null)
            {
                Notificar("Compra não encontrada, ou já excluída");
                return false;
            }

            if (compra.status_compra == StatusCompra.Finalizada)
            {
                foreach (var item in compra.Itens)
                {
                    var produto = await _produtoRepository.GetByIdAsync(item.id_produto);

                    produto.quantidade_estoque = 
                        produto.quantidade_estoque <= 0 ? 0 : produto.quantidade_estoque -= item.quantidade;

                    await _produtoRepository.UpdateAsync(produto);
                }
            }

            await _compraRepository.DeleteAsync(id);
            return true;
        }
        public void Dispose()
        {
            _compraRepository?.Dispose();
            _produtoRepository?.Dispose();
            _fornecedorRepository?.Dispose();
        }
    }
}
