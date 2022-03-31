using FinoSabor.Application.Imagem.Commands;
using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository;
using FinoSabor.Infra.Data.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Pessoas.Commands
{
    public class PessoaCommandHandler : CommandHandler,
        IRequestHandler<AtualizarPessoaCommand, BaseResponse>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<BaseResponse> Handle(AtualizarPessoaCommand request, CancellationToken cancellationToken)
        {
            Pessoa pessoa = new Pessoa();

            if (!ExecutarValidacao(new PessoaValidation(), pessoa)) return new BaseResponse(ValidationResult);

            if (await _pessoaRepository.Existe(f => f.CPF == pessoa.CPF && f.UsuarioId != pessoa.UsuarioId))
            {
                AdicionarErro("Já existe um Usuário com este CPF informado.");
                return new BaseResponse(ValidationResult);
            }
            var pessoaBD = await _pessoaRepository.ObterPor(c => c.UsuarioId == pessoa.UsuarioId);

            if (pessoaBD is null)
            {
                AdicionarErro("Usuário não encontrado");
                new BaseResponse(ValidationResult);
            }
            pessoa.Id = pessoaBD.Id;
            await _pessoaRepository.UpdateAsync(pessoa);

            return new BaseResponse();
        }
      


    }
}
