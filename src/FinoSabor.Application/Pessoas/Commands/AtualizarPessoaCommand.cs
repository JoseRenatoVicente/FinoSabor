using FinoSabor.Domain.Core.Responses;
using MediatR;
using System;

namespace FinoSabor.Application.Pessoas.Commands
{
    public class AtualizarPessoaCommand : IRequest<BaseResponse>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
