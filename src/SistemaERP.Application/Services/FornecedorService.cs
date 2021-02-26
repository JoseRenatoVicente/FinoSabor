using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Base;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Validations;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return false;

            if (_fornecedorRepository.Buscar(f => f.documento == fornecedor.documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _fornecedorRepository.AddAsync(fornecedor);
            return true;
        }


        public async Task<bool> Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return false;

            if (_fornecedorRepository.Buscar(f => f.documento == fornecedor.documento && f.id != fornecedor.id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }

            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task AtualizarEndereco(Endereco_Fornecedor endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
            //erro ao atualizar enderço que nao exite
            await _enderecoRepository.UpdateAsync(endereco);
        }

        public async Task<bool> Remover(Guid id)
        {

            if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return false;
            }

            
            await _enderecoRepository.DeleteAsync(id);
            

            await _fornecedorRepository.DeleteAsync(id);
            return true;
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
