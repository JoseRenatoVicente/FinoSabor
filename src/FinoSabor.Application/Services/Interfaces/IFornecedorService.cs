using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task<PagedList<FornecedorViewModel>> ObterFornecedores(int PagNumero, int PagRegistro, string busca = null);
        Task<Fornecedor> ObterFornecedorPorId(Guid id);
        Task<EnderecoViewModel> ObterEnderecorPorId(Guid id);
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);
        Task<bool> AtualizarEndereco(EnderecoFornecedor endereco);
    }
}
