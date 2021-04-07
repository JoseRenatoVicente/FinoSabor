using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using FinoSabor.Application.ViewModels;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly IMapper _mapper;
        public FornecedorRepository(FinoSaborContext context,
                                 IMapper mapper
            ) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.fornecedor.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<PagedList<FornecedorViewModel>> PaginacaoAsync(int PagNumero, int PagRegistro)
        {
            var iquerable = await GetAllAsync();

            var quantidadeTotalRegistros = await iquerable.CountAsync();
            var list = await iquerable.ProjectTo<FornecedorViewModel>(_mapper.ConfigurationProvider).Skip((PagNumero - 1) * PagRegistro).Take(PagRegistro).ToListAsync();

            return new PagedList<FornecedorViewModel>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = quantidadeTotalRegistros <= PagRegistro ? quantidadeTotalRegistros : PagRegistro,
                TotalRegistros = quantidadeTotalRegistros,
                TotalPaginas = (int)Math.Ceiling((double)quantidadeTotalRegistros / PagRegistro),
                Data = list
            };
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.fornecedor.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.id == id);
        }
    }
}
