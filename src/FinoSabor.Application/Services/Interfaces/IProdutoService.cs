using Microsoft.AspNetCore.Http;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task<IEnumerable<ProdutoViewModel>> ObterProdutos();
        Task<ProdutoViewModel> ObterProdutosPorId(Guid id);
        Task<bool> Adicionar(Produto produto);
        Task<bool> MudarImagemPrincipal(string caminhoImagem);
        Task<bool> Atualizar(Produto produto);
        Task<bool> Remover(Guid id);
        Task<bool> AdicionarImagem(Guid id_produto, IFormFile file, bool ImagemPrincipal = false);
        Task<bool> RemoverImagem(string caminho);
    }
}
