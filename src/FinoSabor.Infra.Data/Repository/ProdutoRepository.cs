using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using FinoSabor.Application.ViewModels;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await Db.Produto.AsNoTracking()
                .ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task<ProdutoClienteViewModel> ObterProdutoPorSlug(string slug)
        {
            return await Db.Produto.AsNoTracking()
                .ProjectTo<ProdutoClienteViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(p => p.slug == slug);
        }


        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosCliente()
        {

            return await Db.Produto.AsNoTracking()
                .Where(c => c.Ativo == true && c.QuantidadeEstoque > 0)
                .ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ProdutoClienteObterTodosViewModel>> ObterProdutosPorIds(string ids)
        {
            var idsGuid = ids.Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<ProdutoClienteObterTodosViewModel>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await Db.Produto.AsNoTracking()
                .Where(p => idsValue.Contains(p.Id) && p.Ativo).ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedList<ProdutoViewModel>> PaginacaoAdminAsync(int PagNumero, int PagRegistro, string busca = null)
        {
            var sql = @$"SELECT Id, Nome, Valor, Descricao, Ativo, QuantidadeEstoque, QuantidadeMinima, ImagemPrincipal, CategoriaId FROM Produtos
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {PagRegistro * (PagNumero - 1)} ROWS 
                      FETCH NEXT {PagRegistro} ROWS ONLY 
                      SELECT COUNT(Id) FROM Produtos
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = busca });

            var list = multi.Read<ProdutoViewModel>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedList<ProdutoViewModel>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = total <= PagRegistro ? total : PagRegistro,
                TotalRegistros = total,
                TotalPaginas = (int)Math.Ceiling((double)total / PagRegistro),
                Data = list
            };
        }


    }
}
