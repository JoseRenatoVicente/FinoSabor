using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Validations;
using FinoSabor.Domain.ViewModels;
using FinoSabor.Domain.ViewModels.Pessoa;
using FinoSabor.Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class PerfilService : BaseService, IPerfilService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public PerfilService(IPessoaRepository pessoaRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<PessoaUpdateViewModel> ObterDados(Guid id_usuario)
        {
            return await (await _pessoaRepository.GetAllAsync())
            .ProjectTo<PessoaUpdateViewModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.id_usuario == id_usuario);
        }

        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            if (!ExecutarValidacao(new PessoaValidation(), pessoa)) return false;

            if (await _pessoaRepository.Existe(f => f.cpf == pessoa.cpf && f.id_usuario != pessoa.id_usuario))
            {
                Notificar("Já existe um Usuário com este CPF informado.");
                return false;
            }
            var pessoaBD = await _pessoaRepository.ObterPor(c => c.id_usuario == pessoa.id_usuario);

            if (pessoaBD == null)
            {
                Notificar("Usuário não encontrado");
                return false;
            }
            pessoa.id = pessoaBD.id;
            await _pessoaRepository.UpdateAsync(pessoa);
            return true;
        }

        public void Dispose()
        {
            _pessoaRepository?.Dispose();
        }
    }
}
