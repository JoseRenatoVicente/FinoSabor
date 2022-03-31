using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Produtos.Queries
{
    public class ProdutoQueries : IProdutoQueries
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoQueries(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutos()
        {
            var iquerable = await _produtoRepository.GetAllAsync();

            return await iquerable
                .ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedList<ProdutoViewModel>> ObterProdutos(int PagNumero, int PagRegistro, string busca = null)
        {
            return await _produtoRepository.PaginacaoAdminAsync(PagNumero, PagRegistro, busca);
        }

        public async Task<ProdutoViewModel> ObterProdutosPorId(Guid id)
        {
            return await _produtoRepository.ObterProdutoPorId(id);
        }
    }
}
