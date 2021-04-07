using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    [AllowAnonymous]
    [Route("api/Admin/Categoria")]
    public class CategoriaAdminController : MainController
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaAdminController(INotificador notificador, IAspNetUser appUser,
                                   IMapper mapper,
                                   ICategoriaService categoriaService) : base(notificador, appUser)
        {
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _categoriaService.ObterCategorias();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Categoria>> ObterPorId(Guid id)
        {
            return await _categoriaService.ObterCategoriaPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel)));
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Atualizar(Categoria categoria)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoriaService.Atualizar(categoria));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Categoria>> Excluir(Guid id)
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

            return CustomResponse(await _categoriaService.Remover(id));
        }

    }
}
