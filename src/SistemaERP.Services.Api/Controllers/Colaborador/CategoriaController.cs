using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaERP.Application.Notificacoes.Interface;
using SistemaERP.Application.ViewModels;
using SistemaERP.Domain.Entities;
using SistemaERP.Infra.CrossCutting.Identity.Extensions.Interfaces;
using SistemaERP.Infra.Data.Repository.Interfaces;
using SistemaERP.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SistemaERP.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Colaborador/[controller]")]
    public class CategoriaController : MainController
    {
        private ICategoriaRepository _categoriaRepository;
        private IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public CategoriaController(INotificador notificador, IAspNetUser appUser,
                                   IMapper mapper,
                                   ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository) : base(notificador, appUser)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Categoria>> ObterCategorias(int PaginaNumero = 1, int PaginaRegistro = 4)
        {
            var categorias = await _categoriaRepository.GetPagingAsync(PaginaNumero, PaginaRegistro);

            if (categorias == null) return NotFound();

            return CustomResponse(categorias);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Categoria>> ObterPorId(Guid id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null) return NotFound();

            return CustomResponse(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Adicionar(Categoria categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            categoria.id = Guid.NewGuid();

            await _categoriaRepository.AddAsync(categoria);


            return CustomResponse(categoria);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Categoria>> Atualizar(Guid id, Categoria categoria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (!await _categoriaRepository.ExisteId(id)) return NotFound();
            //if (!await _categoriaRepository.ExisteId(categoria.CategoriaPaiId)) return NotFound();

            categoria.id = id;

            await _categoriaRepository.UpdateAsync(categoria);

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Categoria>> Excluir(Guid id)
        {

            if (!await _categoriaRepository.ExisteId(id)) return NotFound();



            /*var categoriasFilho = _categoriaRepository.ObterCategoriasPorCategoriaPai(id);
            if (categoriasFilho.Result.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in categoriasFilho.Result)
                {
                    sb.Append($"'{item.nome}' ");
                }

                NotificarErro("Não é possível excluir Categorias que possuem categorias vinculados: " + sb.ToString());
                return CustomResponse();
            }*/


            var produtosCategoria = await _produtoRepository.ObterProdutoPorCategoria(id);
            if (produtosCategoria.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in produtosCategoria)
                {
                    sb.Append($"'{item.nome}' ");
                }

                NotificarErro("Não é possível excluir Categorias que possuem produtos vinculados: " + sb.ToString());
                return CustomResponse();
            }


            await _categoriaRepository.DeleteAsync(id);

            return CustomResponse();
        }

    }
}
