using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinoSabor.Application.ViewModels;
using AutoMapper.QueryableExtensions;

namespace FinoSabor.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
           return await _categoriaRepository.GetAllAsync();
        }

        [HttpGet("produtos/{slug}")]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutoPorCategoria(string slug)
        {
            return (await _produtoRepository.GetAllAsync()).Where(c => c.Categoria.slug == slug)
                .ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
