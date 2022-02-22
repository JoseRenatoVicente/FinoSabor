using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinoSabor.Application.Notificacoes.Interface;
using FinoSabor.Application.Services.Interfaces;
using FinoSabor.Application.ViewModels;
using FinoSabor.Domain.Entities;
using FinoSabor.Domain.Helpers;
using FinoSabor.Infra.CrossCutting.Identity.Extensions.Interfaces;
using FinoSabor.Services.Api.Controllers.Base;
using System;
using System.Collections.Generic;
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
                                     IFornecedorService fornecedorService,
                                     INotificador notificador, IAspNetUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }


        [HttpGet]
        public async Task<PagedList<FornecedorViewModel>> ObterTodos(int PagNumero = 1 , int PagRegistro = 10, string busca = null)
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
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _fornecedorService.Adicionar(fornecedor));
        }

        [HttpPut]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Fornecedor fornecedor)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _fornecedorService.Atualizar(fornecedor));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            return CustomResponse(await _fornecedorService.Remover(id));
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _fornecedorService.ObterEnderecorPorId(id));
        }

        [HttpPut("endereco")]
        public async Task<IActionResult> AtualizarEndereco(EnderecoFornecedor endereco)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _fornecedorService.AtualizarEndereco(endereco));
        }

    }
}
