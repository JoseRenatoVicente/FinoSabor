using AutoMapper;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Domain.Validations;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<PagedList<FornecedorViewModel>> ObterFornecedores(int PagNumero, int PagRegistro, string busca = null)
        {
            return await _fornecedorRepository.PaginacaoAsync(PagNumero, PagRegistro, busca);
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid id)
        {
            return await ObterFornecedorProdutosEndereco(id);
        }

        public async Task<EnderecoViewModel> ObterEnderecorPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.GetByIdAsync(id));
        }

        public async Task<bool> Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                || !ExecutarValidacao(new Endereco_FornecedorValidation(), fornecedor.Endereco)) return false;

            if (await _fornecedorRepository.Existe(f => f.Cnpj == fornecedor.Cnpj))
            {
                Notificar("Já existe um fornecedor com este cnpj informado.");
                return false;
            }

            await _fornecedorRepository.AddAsync(fornecedor);
            return true;
        }

        public async Task<bool> Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return false;

            if (await _fornecedorRepository.Existe(f => f.Cnpj == fornecedor.Cnpj && f.Id != fornecedor.Id))
            {
                Notificar("Já existe um fornecedor com este cnpj informado.");
                return false;
            }

            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _fornecedorRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> AtualizarEndereco(EnderecoFornecedor endereco)
        {
            if (!ExecutarValidacao(new Endereco_FornecedorValidation(), endereco)) return false;

            await _enderecoRepository.UpdateAsync(endereco);
            return true;
        }

        private async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
