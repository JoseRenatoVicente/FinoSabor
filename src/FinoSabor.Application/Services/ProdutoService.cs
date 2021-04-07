using AutoMapper;
using Microsoft.AspNetCore.Http;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Base;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Validations;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FinoSabor.Application.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IImagemRepository _imagemRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAspNetUser _user;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IImagemRepository imagemRepository,
                              ICategoriaRepository categoriaRepository,
                              IMapper mapper,
                              INotificador notificador,
                              IAspNetUser user) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _imagemRepository = imagemRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _user = user;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutos()
        {
            return await _produtoRepository.ObterProdutosCategoria();
        }

        public async Task<ProdutoViewModel> ObterProdutosPorId(Guid id)
        {
            return await _produtoRepository.ObterProdutoPorId(id);
        }

        public async Task CalcularFrete(int CEP)
        {
            
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            if (!await _categoriaRepository.Existe(c => c.id == produto.id_categoria))
            {
                Notificar("Categoria não encontrada");
                return false;
            }

            await _produtoRepository.AddAsync(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            await _produtoRepository.UpdateAsync(produto);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _produtoRepository.DeleteAsync(id);
            return true;
        }
        public async Task<bool> AdicionarImagem(Guid id_produto, IFormFile file, bool ImagemPrincipal = false)
        {
            if (file == null || file.Length == 0)
            {
                Notificar("Forneça uma imagem para este produto!");
                return false;
            }

            var produto = await _produtoRepository.GetByIdAsync(id_produto);

            if (!await _produtoRepository.Existe(c => c.id == id_produto))
            {
                Notificar("Produto não encontrado");
                return false;
            }


            var nome = Guid.NewGuid() + "_" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);


            if (File.Exists(path)) path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", file.FileName + Guid.NewGuid());

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            if (ImagemPrincipal)
            {
                if (produto.imagem_principal != null)
                {
                    await _imagemRepository.AddAsync(new Imagem_Produto { caminho = produto.imagem_principal, id_produto = produto.id });
                }
                produto.imagem_principal = nome;
                await _produtoRepository.UpdateAsync(produto);
            }
            else
            {
                await _imagemRepository.AddAsync(new Imagem_Produto { caminho = nome, id_produto = id_produto });
            }

            return true;
        }
        public async Task<bool> MudarImagemPrincipal(string caminhoImagem)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.caminho == caminhoImagem);

            if (imagem == null)
            {
                Notificar("Imagem não encontrada");
                return false;
            }

            var produto = await _produtoRepository.GetByIdAsync(imagem.id_produto);

            if (produto.imagem_principal != null)
            {
                await _imagemRepository.AddAsync(new Imagem_Produto { caminho = produto.imagem_principal, id_produto = imagem.id_produto });
            }

            produto.imagem_principal = imagem.caminho;
            await _produtoRepository.UpdateAsync(produto);
            await _imagemRepository.DeleteAsync(imagem.id);

            return true;
        }


        public async Task<bool> RemoverImagem(string caminho)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.caminho == caminho);

            string imagemDeletada;
            if (imagem != null)
            {
                await _imagemRepository.DeleteAsync(imagem.id);
                imagemDeletada = imagem.caminho;
            }
            else if (await _produtoRepository.Existe(c => c.imagem_principal == caminho))
            {
                var produto = await _produtoRepository.ObterPor(c => c.imagem_principal == caminho);
                
                imagemDeletada = produto.imagem_principal;

                produto.imagem_principal = null;
                await _produtoRepository.UpdateAsync(produto);

            }
            else
            {
                Notificar("Imagem não encontrada");
                return false;
            }


            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imagemDeletada);


            if (File.Exists(file))
            {
                using FileStream stream = new FileStream(file, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true);

                await stream.FlushAsync();
                File.Delete(file);
            }

            return true;
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _imagemRepository?.Dispose();
        }
    }
}
