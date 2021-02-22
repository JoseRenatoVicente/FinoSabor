using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.Services.Interfaces;
using SistemaERP.Application.ViewModels;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Colaborador/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IImagemRepository _imagemRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador,
                                  IImagemRepository imagemRepository,
                                  IProdutoRepository produtoRepository,
                                  ICategoriaRepository categoriaRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  IProdutoService produtoService,
                                  IMapper mapper,
                                  IAspNetUser user) : base(notificador, user)
        {
            _imagemRepository = imagemRepository;
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _fornecedorRepository = fornecedorRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Produto>> ObterPorId(Guid id)
        {
            var produtoViewModel = await _produtoRepository.ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            produtoViewModel.Id = Guid.NewGuid();

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [HttpPost("uploadImage/{id:guid}")]
        public async Task<ActionResult> AdicionarImagemProduto(Guid id, IFormFile file)
        {
            if (!await _produtoRepository.ExisteId(id)) return NotFound();

            if (file == null || file.Length == 0)
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return CustomResponse();
            }

            var nome = Guid.NewGuid() + "_" + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nome);


            if (System.IO.File.Exists(path))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return CustomResponse();
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            await _imagemRepository.AddAsync(new ProdutoImagem { Caminho = nome, ProdutoId = id });

            return Ok();
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!await _produtoRepository.ExisteId(id)) return NotFound();
            if (!await _categoriaRepository.ExisteId(produtoViewModel.CategoriaId)) return NotFound();
            if (!await _fornecedorRepository.ExisteId(produtoViewModel.FornecedorId)) return NotFound();

            produtoViewModel.Id = id;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {

            if (!await _produtoRepository.ExisteId(id)) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse();
        }

        [HttpDelete("deleteImage{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ExcluirImagem(Guid id)
        {

            //terminar
            var imagem = await _imagemRepository.GetByIdAsync(id);

            if (imagem == null) return NotFound();

            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imagem.Caminho);

            using (FileStream stream = new FileStream(file, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true))
            {
                await stream.FlushAsync();
                System.IO.File.Delete(file);
            }

            await _imagemRepository.DeleteAsync(id);

            return CustomResponse(imagem);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
        }
    }
}
