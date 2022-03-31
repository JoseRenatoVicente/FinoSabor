using Dapper;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(FinoSaborContext context) : base(context) { }



        public async Task<PagedList<PessoaViewModel>> PaginacaoGetAllAdminAsync(int PagNumero, int PagRegistro, string busca = null)
        {
            var sql = @$"SELECT pessoa.Id, pessoa.Nome, pessoa.Telefone, pessoa.CPF, pessoa.DataNascimento, pessoa.DataCadastro, usuario.Email
                      FROM Pessoa
                      INNER JOIN Usuario
                      ON Usuario.Id = Pessoa.UsuarioId
                      INNER JOIN UsuarioFuncao
                      ON usuario.Id = UsuarioFuncao.UserId 
                      WHERE RoleId = '4EFE97B7-493D-4EAF-BA0B-7407C76C6803' AND (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {PagRegistro * (PagNumero - 1)} ROWS 
                      FETCH NEXT {PagRegistro} ROWS ONLY 
                      SELECT COUNT(Id) FROM Pessoa 
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = busca });

            var list = multi.Read<PessoaViewModel>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedList<PessoaViewModel>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = total <= PagRegistro ? total : PagRegistro,
                TotalRegistros = total,
                TotalPaginas = (int)Math.Ceiling((double)total / PagRegistro),
                Data = list
            };
        }

        public async Task<PagedList<PessoaViewModel>> PaginacaoGetAllClientesAsync(int PagNumero, int PagRegistro, string busca = null)
        {
            var sql = @$"SELECT pessoa.id, pessoa.Nome, pessoa.telefone, pessoa.cpf, pessoa.data_nascimento, pessoa.data_cadastro, usuario.Email
                      FROM pessoa
                      INNER JOIN usuario
                      ON usuario.Id = pessoa.id_usuario
                      INNER JOIN usuario_funcao
                      ON usuario.Id = usuario_funcao.UserId 
                      WHERE RoleId = '490018AD-BCD6-4AA9-EC4A-08D9247FB19A' AND (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%') 
                      ORDER BY [Nome] 
                      OFFSET {PagRegistro * (PagNumero - 1)} ROWS 
                      FETCH NEXT {PagRegistro} ROWS ONLY 
                      SELECT COUNT(Id) FROM pessoa 
                      WHERE (@Nome IS NULL OR Nome LIKE '%' + @Nome + '%')";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql, new { Nome = busca });

            var list = multi.Read<PessoaViewModel>();
            var total = multi.Read<int>().FirstOrDefault();

            return new PagedList<PessoaViewModel>
            {
                NumeroPagina = PagNumero,
                RegistroPorPagina = total <= PagRegistro ? total : PagRegistro,
                TotalRegistros = total,
                TotalPaginas = (int)Math.Ceiling((double)total / PagRegistro),
                Data = list
            };
        }

        /*public async Task<IEnumerable<PessoaViewModel>> GetAllComuns()
        {
            var sql = @"SELECT pessoa.id, pessoa.Nome, pessoa.telefone, pessoa.cpf, pessoa.data_nascimento, pessoa.data_cadastro, usuario.Email
                        FROM pessoa
                        INNER JOIN usuario
                        ON usuario.Id = pessoa.id_usuario
                        INNER JOIN usuario_funcao
                        ON usuario.Id = usuario_funcao.UserId 
                        WHERE RoleId = '490018AD-BCD6-4AA9-EC4A-08D9247FB19A'";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql);

            var pessoa = multi.Read<PessoaViewModel>();

            return pessoa;

        }*/

        /*public async Task<PessoaDetalhesViewModel> GetByIdAsync(Guid id)
        {
            var sql = @"SELECT pessoa.Nome, pessoa.telefone, pessoa.data_cadastro, pessoa.cpf, pessoa.data_nascimento, pessoa.rua, pessoa.numero,
                        pessoa.complemento, pessoa.cep, pessoa.bairro, pessoa.cidade, pessoa.estado, usuario.Email
                        FROM pessoa
                        INNER JOIN usuario
                        ON usuario.Id = pessoa.id_usuario
                        WHERE pessoa.id = '3A62A062-71CE-453F-B0EE-2F58A4AAEEB5'";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql);

            var pessoa = multi.Read<PessoaViewModel>();

            return pessoa;
        }*/

    }
}
