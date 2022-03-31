using AutoMapper;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Services.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinoSabor.Services.Api.Controllers.Colaborador
{
    //[Authorize(Roles = "admin")]
    [Route("api/Admin/Fornecedor")]
    public class FornecedoresAdminController : MainController
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresAdminController(IMapper mapper,
                                     IFornecedorService fornecedorService)
        {
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }


        [HttpGet]
        public async Task<PagedList<FornecedorViewModel>> ObterTodos(int PagNumero = 1, int PagRegistro = 10, string busca = null)
        {
            return await _fornecedorService.ObterFornecedores(PagNumero, PagRegistro, busca);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Fornecedor>> ObterPorId(Guid id)
        {
            return await _fornecedorService.ObterFornecedorPorId(id);
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> Adicionar(Fornecedor fornecedor)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _fornecedorService.Adicionar(fornecedor));
        }

        [HttpPut]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Fornecedor fornecedor)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _fornecedorService.Atualizar(fornecedor));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            return CustomResponseAsync(await _fornecedorService.Remover(id));
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _fornecedorService.ObterEnderecorPorId(id));
        }

        [HttpPut("endereco")]
        public async Task<IActionResult> AtualizarEndereco(EnderecoFornecedor endereco)
        {
            return !ModelState.IsValid ? CustomResponseAsync(ModelState) : CustomResponseAsync(await _fornecedorService.AtualizarEndereco(endereco));
        }

    }
}
