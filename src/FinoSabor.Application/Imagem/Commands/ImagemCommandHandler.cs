using FinoSabor.Domain.Core.Messages;
using FinoSabor.Domain.Core.Responses;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FinoSabor.Application.Imagem.Commands
{
    public class ImagemCommandHandler: CommandHandler,
        IRequestHandler<AdicionarImagemCommand, BaseResponse>,
        IRequestHandler<MudarImagemPrincipalCommand, BaseResponse>,
        IRequestHandler<RemoverImagemCommand, BaseResponse>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IImagemRepository _imagemRepository;

        public ImagemCommandHandler(IProdutoRepository produtoRepository,
                              IImagemRepository imagemRepository) 
        {
            _produtoRepository = produtoRepository;
            _imagemRepository = imagemRepository;
        }

        public async Task<BaseResponse> Handle(AdicionarImagemCommand request, CancellationToken cancellationToken)
        {
            if (request.File is null || request.File.Length == 0)
            {
                AdicionarErro("Forneça uma imagem para este produto!");
                return new BaseResponse(ValidationResult);
            }

            var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

            if (!await _produtoRepository.Existe(c => c.Id == request.ProdutoId))
            {
                AdicionarErro("Produto não encontrado");
                return new BaseResponse(ValidationResult);
            }


            var nome = Guid.NewGuid() + "_" + request.File.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }
            if (request.ImagemPrincipal)
            {
                if (produto.ImagemPrincipal is not null)
                {
                    await _imagemRepository.AddAsync(new ImagemProduto { Caminho = produto.ImagemPrincipal, ProdutoId = produto.Id });
                }
                produto.ImagemPrincipal = nome;
                await _produtoRepository.UpdateAsync(produto);
            }
            else
            {
                await _imagemRepository.AddAsync(new ImagemProduto { Caminho = nome, ProdutoId = request.ProdutoId });
            }

            return new BaseResponse();
        }
        public async Task<BaseResponse> Handle(MudarImagemPrincipalCommand request, CancellationToken cancellationToken)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.Caminho == request.CaminhoImagem);

            if (imagem is null)
            {
                AdicionarErro("Imagem não encontrada");
                return new BaseResponse(ValidationResult);
            }

            var produto = await _produtoRepository.GetByIdAsync(imagem.ProdutoId);

            if (produto.ImagemPrincipal is not null)
            {
                await _imagemRepository.AddAsync(new ImagemProduto { Caminho = produto.ImagemPrincipal, ProdutoId = imagem.ProdutoId });
            }

            produto.ImagemPrincipal = imagem.Caminho;
            await _produtoRepository.UpdateAsync(produto);
            await _imagemRepository.DeleteAsync(imagem.Id);

            return new BaseResponse();
        }


        public async Task<BaseResponse> Handle(RemoverImagemCommand request, CancellationToken cancellationToken)
        {
            var imagem = await _imagemRepository.ObterPor(c => c.Caminho == request.CaminhoImagem);

            string imagemDeletada;
            if (imagem is not null)
            {
                await _imagemRepository.DeleteAsync(imagem.Id);
                imagemDeletada = imagem.Caminho;
            }
            else if (await _produtoRepository.Existe(c => c.ImagemPrincipal == request.CaminhoImagem))
            {
                var produto = await _produtoRepository.ObterPor(c => c.ImagemPrincipal == request.CaminhoImagem);

                imagemDeletada = produto.ImagemPrincipal;

                produto.ImagemPrincipal = null;
                await _produtoRepository.UpdateAsync(produto);

            }
            else
            {
                AdicionarErro("Imagem não encontrada");
                return new BaseResponse(ValidationResult);
            }


            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imagemDeletada);


            if (File.Exists(file))
            {
                using FileStream stream = new FileStream(file, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true);

                await stream.FlushAsync();
                File.Delete(file);
            }

            return new BaseResponse();
        }
    }
}
