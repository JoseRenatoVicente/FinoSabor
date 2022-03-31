using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Domain.Entities;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public CategoriaController(IMapper mapper,
                                   ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository)
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
            return (await _produtoRepository.GetAllAsync()).Where(c => c.Categoria.Slug == slug)
                .ProjectTo<ProdutoClienteObterTodosViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
