using Microsoft.EntityFrameworkCore;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.ViewModels.Cliente;

namespace FinoSabor.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly IMapper _mapper;
        public ProdutoRepository(FinoSaborContext context,
                                 IMapper mapper
            ) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            return await Db.produto.AsNoTracking()
                .ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.id == id);

        }

        public async Task<ProdutoClienteViewModel> ObterProdutoPorSlug(string slug)
        {
            return await Db.produto.AsNoTracking()
                .ProjectTo<ProdutoClienteViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.slug == slug);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutosCategoria()
        {
            return await Db.produto.AsNoTracking()
                .ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosCliente()
        {

            return await Db.produto.AsNoTracking()
                .ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


    }
}
