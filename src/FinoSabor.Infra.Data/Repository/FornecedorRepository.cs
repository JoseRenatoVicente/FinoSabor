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
using Dapper;

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

        public async Task<PagedList<FornecedorViewModel>> PaginacaoAsync(int PagNumero, int PagRegistro, string busca = null)
        {
            var sql = @$"SELECT * FROM fornecedor
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {PagRegistro * (PagNumero - 1)} ROWS 
                      FETCH NEXT {PagRegistro} ROWS ONLY 
                      SELECT COUNT(Id) FROM fornecedor 
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = busca });

            var list = multi.Read<FornecedorViewModel>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedList<FornecedorViewModel>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = total <= PagRegistro ? total : PagRegistro,
                TotalRegistros = total,
                TotalPaginas = (int)Math.Ceiling((double)total / PagRegistro),
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
