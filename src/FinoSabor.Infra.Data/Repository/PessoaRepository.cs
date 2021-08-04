using Dapper;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Base.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Infra.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(FinoSaborContext context) : base(context) { }




        public async Task<IEnumerable<PessoaViewModel>> GetAllAdmins()
        {
            var sql = @"SELECT pessoa.id, pessoa.Nome, pessoa.telefone, pessoa.cpf, pessoa.data_nascimento, pessoa.data_cadastro, usuario.Email
                        FROM pessoa
                        INNER JOIN usuario
                        ON usuario.Id = pessoa.id_usuario
                        INNER JOIN usuario_funcao
                        ON usuario.Id = usuario_funcao.UserId 
                        WHERE RoleId = '4EFE97B7-493D-4EAF-BA0B-7407C76C6803'";

            var multi = await Db.Database.GetDbConnection()
                .QueryMultipleAsync(sql);

            var pessoa = multi.Read<PessoaViewModel>();

            return pessoa;

        }

        public async Task<IEnumerable<PessoaViewModel>> GetAllComuns()
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

        }

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
