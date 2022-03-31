using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels.Cliente;
using FinoSabor.Infra.Data.Repository.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Cliente
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterTodos()
        {
            return await _produtoRepository.ObterProdutosCliente();
        }

        /*[HttpGet("catalogo/")]
        public async Task<PagedResult<Produto>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            return await _produtoRepository.ObterTodos(ps, page, q);
        }*/

        [HttpGet("{slug}")]
        public async Task<ActionResult<ProdutoClienteViewModel>> ObterPorId(string slug)
        {
            return await _produtoRepository.ObterProdutoPorSlug(slug);
        }


        [HttpGet("lista/{ids}")]
        public async Task<IEnumerable<ProdutoClienteObterTodosViewModel>> ObterProdutosPorId(string ids)
        {
            return await _produtoRepository.ObterProdutosPorIds(ids);
        }

    }
}
