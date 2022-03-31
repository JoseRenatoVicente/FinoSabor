using AutoMapper;
using FinoSabor.Application.Categorias.Commands;
using FinoSabor.Application.Categorias.Queries;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Services.Api.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    //[Authorize(Roles = "admin")]
    [Route("api/Admin/Categoria")]
    public class CategoriaAdminController : MainController
    {
        private readonly ICategoriaQueries _categoriaQueries;
        private readonly IMediator _mediator;

        public CategoriaAdminController(ICategoriaQueries categoriaQueries, IMediator mediator)
        {
            _categoriaQueries = categoriaQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _categoriaQueries.ObterCategorias();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Categoria>> ObterPorId(Guid id)
        {
            return await _categoriaQueries.ObterCategoriaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(AdicionarCategoriaCommand adicionarCategoriaCommand)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _mediator.Send(adicionarCategoriaCommand));
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Atualizar(AtualizarCategoriaCommand atualizarCategoriaCommand)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _mediator.Send(atualizarCategoriaCommand));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Categoria>> Excluir(RemoverCategoriaCommand removerCategoriaCommand)
        {
            /*
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
            /*

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

            return CustomResponse();*/

            return CustomResponseAsync(await _mediator.Send(removerCategoriaCommand));
        }

    }
}
