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
using FinoSabor.Domain.Helpers;
using Dapper;

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


        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosCliente()
        {

            return await Db.produto.AsNoTracking()
                .Where(c => c.ativo == true && c.quantidade_estoque > 0)
                .ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ProdutoClienteObterTodosViewModel>> ObterProdutosPorIds(string ids)
        {
            var idsGuid = ids.Split(',')
                .Select(id => (Ok: Guid.TryParse(id, out var x), Value: x));

            if (!idsGuid.All(nid => nid.Ok)) return new List<ProdutoClienteObterTodosViewModel>();

            var idsValue = idsGuid.Select(id => id.Value);

            return await Db.produto.AsNoTracking()
                .Where(p => idsValue.Contains(p.id) && p.ativo).ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedList<ProdutoViewModel>> PaginacaoAdminAsync(int PagNumero, int PagRegistro, string busca = null)
        {
            var sql = @$"SELECT id, nome, valor, descricao, ativo, quantidade_estoque, quantidade_minima, imagem_principal, id_categoria FROM produto
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {PagRegistro * (PagNumero - 1)} ROWS 
                      FETCH NEXT {PagRegistro} ROWS ONLY 
                      SELECT COUNT(Id) FROM produto 
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
