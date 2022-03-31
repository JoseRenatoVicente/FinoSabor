using AutoMapper;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Application.Fornecedores.Queries
{
    public class FornecedorQueries : IFornecedorQueries
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedorQueries(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
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

        private async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);
        }


    }
}
