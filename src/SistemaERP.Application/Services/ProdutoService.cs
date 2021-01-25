using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Base;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Domain.Entities;
using SistemaERP.Domain.Validations;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SistemaERP.Application.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAspNetUser _user;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador,
                              IAspNetUser user) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _user = user;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            //var user = _user.GetUserId();

            await _produtoRepository.AddAsync(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.DeleteAsync(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
