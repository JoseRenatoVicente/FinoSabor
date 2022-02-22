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
using FinoSabor.Domain.Helpers;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

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
            var iquerable = await _produtoRepository.GetAllAsync();

            return await iquerable
                .ProjectTo<ProdutoViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PagedList<ProdutoViewModel>> ObterProdutos(int PagNumero, int PagRegistro, string busca = null)
        {
            return await _produtoRepository.PaginacaoAdminAsync(PagNumero, PagRegistro, busca);
        }

        public async Task<ProdutoViewModel> ObterProdutosPorId(Guid id)
        {
            return await _produtoRepository.ObterProdutoPorId(id);
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            if (!await _categoriaRepository.Existe(c => c.Id == produto.IdCategoria))
            {
                Notificar("Categoria não encontrada");
                return false;
            }
            if (await _produtoRepository.Existe(c => c.Slug == produto.Slug))
            {
                Notificar("Já existe um produto com o nome " + produto.Nome);
                return false;
            }            
            produto.Slug = produto.Nome.Slugify();

            await _produtoRepository.AddAsync(produto);
            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            produto.Slug = produto.Nome.Slugify();
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
            if (file is null || file.Length == 0)
            {
                Notificar("Forneça uma imagem para este produto!");
                return false;
            }

            var produto = await _produtoRepository.GetByIdAsync(id_produto);

            if (!await _produtoRepository.Existe(c => c.Id == id_produto))
            {
                Notificar("Produto não encontrado");
                return false;
            }


            var nome = Guid.NewGuid() + "_" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            if (ImagemPrincipal)
            {
                if (produto.ImagemPrincipal != null)
                {
                    await _imagemRepository.AddAsync(new ImagemProduto { Caminho = produto.ImagemPrincipal, IdProduto = produto.Id });
                }
                produto.ImagemPrincipal = nome;
                await _produtoRepository.UpdateAsync(produto);
            }
            else
            {
                await _imagemRepository.AddAsync(new ImagemProduto { Caminho = nome, IdProduto = id_produto });
            }

            return true;
        }
        public async Task<bool> MudarImagemPrincipal(string caminhoImagem)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.Caminho == caminhoImagem);

            if (imagem is null)
            {
                Notificar("Imagem não encontrada");
                return false;
            }

            var produto = await _produtoRepository.GetByIdAsync(imagem.IdProduto);

            if (produto.ImagemPrincipal != null)
            {
                await _imagemRepository.AddAsync(new ImagemProduto { Caminho = produto.ImagemPrincipal, IdProduto = imagem.IdProduto });
            }

            produto.ImagemPrincipal = imagem.Caminho;
            await _produtoRepository.UpdateAsync(produto);
            await _imagemRepository.DeleteAsync(imagem.Id);

            return true;
        }


        public async Task<bool> RemoverImagem(string caminho)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.Caminho == caminho);

            string imagemDeletada;
            if (imagem != null)
            {
                await _imagemRepository.DeleteAsync(imagem.Id);
                imagemDeletada = imagem.Caminho;
            }
            else if (await _produtoRepository.Existe(c => c.ImagemPrincipal == caminho))
            {
                var produto = await _produtoRepository.ObterPor(c => c.ImagemPrincipal == caminho);
                
                imagemDeletada = produto.ImagemPrincipal;

                produto.ImagemPrincipal = null;
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
